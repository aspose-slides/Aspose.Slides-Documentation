---
title: Docker で Aspose.Slides for Java を実行する
linktitle: Docker
type: docs
weight: 150
url: /ja/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- マルチステージビルド
- コンテナイメージ
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- フォント
- PDF変換
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Docker で Aspose.Slides for Java アプリケーションを構築および実行します。公式の Maven と Eclipse Temurin イメージを使用したマルチステージ Dockerfile、Aspose.Slides が必要とする Linux ライブラリとフォント、そして生成されたファイルをマシンにコピーする方法を紹介します。"
---
## **概要**

この記事では、Docker コンテナ内で Aspose.Slides for Java を実行する方法を示します。テキストボックスを持つプレゼンテーションを作成し PDF に変換する小規模な Maven プロジェクトを構築し、公式の Maven および Eclipse Temurin イメージ上のマルチステージ Dockerfile でパッケージ化し、実行して生成されたファイルをマシンにコピーします。また、Linux イメージで Java 以外に Aspose.Slides が必要とするものを説明し、Alpine Linux 用やディストリビューションのパッケージで Java をインストールするイメージ向けのバリエーションで締めくくります。

マシンには Docker だけが必要です。JDK と Maven はビルド用イメージに含まれているため、別途インストールする必要はありません。Docker のインストール方法については、[Docker の取得](https://docs.docker.com/get-started/get-docker/) を参照してください。

## **ベースイメージの選択**

この記事の Dockerfile では、Docker Hub の公式イメージを 2 つ使用しています:

- [maven](https://hub.docker.com/_/maven)  `3.9-eclipse-temurin-21` タグの maven はアプリケーションをビルドします。Apache Maven 3.9 と Eclipse Temurin JDK 21 が含まれています。
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin)  `21-jre` タグの eclipse-temurin は実行用です。Ubuntu 上の Eclipse Temurin Java 21 ランタイムが含まれ、JDK と Maven は含まれていません。

Aspose.Slides for Java は Java のフォントサポートでテキストを描画しますが、Linux では fontconfig と FreeType ライブラリ、および少なくとも 1 つのインストール済みフォントが必要です。Eclipse Temurin イメージにはすでに fontconfig、FreeType、DejaVu フォントが含まれているため、この記事の Dockerfile では追加パッケージをインストールしません。フォントがまったく無いイメージでプレゼンテーションを保存しようとすると「Fontconfig head is null, check your fonts or fonts configuration」というエラーで停止します。別のベースイメージでビルドする場合は、[別のベースイメージの使用](#use-another-base-image) を参照してください。

## **プロジェクトの作成**

*hello-slides-docker* というフォルダーを作成し、以下のファイルを追加します。

*pom.xml* は Aspose の Maven リポジトリと Aspose.Slides for Java の依存関係を宣言します（[インストール](/slides/ja/java/installation/) 参照）。Aspose.Slides for Java は Maven Central で公開されていないため、リポジトリエントリが必要です。`finalName` 要素はアプリケーション JAR ファイル名を *hello-slides.jar* とし、[maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) がパッケージ時にアプリケーションの依存関係を *target/lib* にコピーします。Aspose.Slides のバージョンは [リポジトリ](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) に一覧されている最新バージョンに設定してください。

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-slides</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
    </properties>

    <repositories>
        <repository>
            <id>AsposeJavaAPI</id>
            <name>Aspose Java API</name>
            <url>https://releases.aspose.com/java/repo/</url>
        </repository>
    </repositories>

    <dependencies>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides</artifactId>
            <version>26.9</version>
            <classifier>jdk16</classifier>
        </dependency>
    </dependencies>

    <build>
        <finalName>hello-slides</finalName>
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-dependency-plugin</artifactId>
                <version>3.11.0</version>
                <executions>
                    <execution>
                        <phase>package</phase>
                        <goals>
                            <goal>copy-dependencies</goal>
                        </goals>
                        <configuration>
                            <outputDirectory>${project.build.directory}/lib</outputDirectory>
                        </configuration>
                    </execution>
                </executions>
            </plugin>
        </plugins>
    </build>
</project>
```

*src/main/java/HelloSlides.java* は [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) を作成し、最初のスライドにテキスト付きの矩形を追加し、[save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.lang.String-int-) メソッドで PPTX と PDF の 2 つの形式で保存します。両方のファイルは作業ディレクトリ配下の *output* フォルダーに出力されます。その後、Aspose.Slides がプレゼンテーションをレンダリングするときに置き換えるフォントを [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) で列挙し、コンテナ内にプレゼンテーションが使用するフォントが存在するか確認できます。

```java
import com.aspose.slides.*;
import java.io.File;

public class HelloSlides {
    public static void main(String[] args) {
        File outputFolder = new File("output");
        outputFolder.mkdirs();

        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello from a Docker container!");

            String pptxPath = new File(outputFolder, "hello.pptx").getPath();
            String pdfPath = new File(outputFolder, "hello.pdf").getPath();
            presentation.save(pptxPath, SaveFormat.Pptx);
            presentation.save(pdfPath, SaveFormat.Pdf);

            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                System.out.println("Font substitution: " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
            }

            System.out.println("Saved " + pptxPath + " and " + pdfPath);
        } finally {
            presentation.dispose();
        }
    }
}
```

*.dockerignore* はローカルビルド時の *target* フォルダーと以前の実行結果を Docker ビルドコンテキストから除外し、イメージがソースファイルだけで構築されるようにします。

```text
target/
output/
```

## **Dockerfile の作成**

*hello-slides-docker* フォルダーに *Dockerfile* という名前のファイルを追加します:

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

ファイルは 2 つのステージから構成します:

- **ビルドステージ** は Maven イメージから開始します。最初に *pom.xml* をコピーし `mvn dependency:go-offline` を実行して Aspose.Slides for Java と Maven プラグインをダウンロードします。これにより *pom.xml* が変更されない限り Docker はこのレイヤーを再利用します。その後、ソースコードをコピーし `mvn package` を実行してプログラムを *target/hello-slides.jar* にコンパイルし、Aspose.Slides JAR を *target/lib* にコピーします。`-B` オプションは Maven をバッチモード（非対話）で実行します。
- **ランタイムステージ** は小さい Java ランタイムイメージから開始し、アプリケーション JAR と *lib* フォルダーだけをコピーします。*output* フォルダーを作成し、Ubuntu 系イメージが定義する非 root ユーザー `ubuntu` に所有権を付与し、そのユーザーでアプリケーションを実行します。クラスパス `hello-slides.jar:lib/*` にはアプリケーションと *lib* 内のすべての JAR が含まれ、`*` は Java が展開します。

プロジェクトは Java 11 用にコンパイルされています（`maven.compiler.release` プロパティ）。したがってランタイムステージでは新しい Java バージョンを使用できます。例として Java 25 で実行する場合は、ランタイムステージのイメージを `eclipse-temurin:25-jre` に変更してください。

## **コンテナのビルドと実行**

*hello-slides-docker* フォルダーでターミナルを開きます。イメージをビルドし、コンテナを実行します:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

最初のビルドではベースイメージ、Maven プラグイン、Aspose.Slides for Java がダウンロードされるため数分かかりますが、以降のビルドはそれらを再利用します。コンテナはアプリケーションを実行して停止し、次のように出力します:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

最初の行はテキストが新規プレゼンテーションのデフォルトフォントである Calibri を使用しているが、イメージに Calibri がインストールされていないため Aspose.Slides が DejaVu Sans で描画したことを示しています。PDF のテキストは実際の文字として選択可能です。ライセンスがない場合、Aspose.Slides は保存するすべてのスライドに評価版の透かしを追加します。詳細は [ライセンス](/slides/ja/java/licensing/) を参照してください。

## **出力のマシンへのコピー**

停止したコンテナの */app/output* フォルダーにファイルが格納されています。これらをマシン上の *output* フォルダーにコピーし、コンテナを削除します:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

これらの 2 つのコマンドは Bash、PowerShell、Windows コマンドプロンプトすべてで同じように動作します。

Linux では、代わりにマシン側のフォルダーをコンテナにマウントして、アプリケーションが直接そのフォルダーに書き込むようにすることもできます:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

`--user` オプションは自分のユーザー ID とグループ ID でアプリケーションを実行するため、作成したフォルダーに書き込め、生成されたファイルは自分の所有になります。`--rm` はコンテナ停止時に自動的に削除します。

## **Alpine Linux での実行**

Eclipse Temurin は Alpine Linux ベースのイメージとしても提供されており、サイズが小さくなります。このイメージにも fontconfig、FreeType、DejaVu フォントが含まれるため、追加パッケージは不要です。使用するには、*Dockerfile* のランタイムステージ（2 行目の `FROM` 以降）を次の内容に置き換えます:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Alpine イメージには `ubuntu` ユーザーが存在しないため、このステージでは `adduser` で `app` ユーザーを作成し、そのユーザーでアプリケーションを実行します。ビルド、実行、出力のコピーは上記と同じコマンドで行え、アプリケーションは同じ 2 行を出力します。

## **別のベースイメージの使用**

イメージがディストリビューションのパッケージから Java をインストールする場合は、Java のフォントライブラリとフォントも同時にインストールする必要があります。Debian と Ubuntu では `openjdk-21-jre-headless` パッケージは fontconfig、FreeType、HarfBuzz を「推奨」パッケージとして扱うだけなので、`apt-get install --no-install-recommends` でインストールするとそれらが除外され、`libfontmanager.so` に対する `UnsatisfiedLinkError` で停止します。以下のランタイムステージは Debian 13 に Java 21、必要なライブラリ、DejaVu フォントをインストールし、非 root ユーザー `app` を作成します:

```dockerfile
FROM debian:trixie
RUN apt-get update \
    && apt-get install -y --no-install-recommends openjdk-21-jre-headless libfontconfig1 libfreetype6 libharfbuzz0b fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN useradd --create-home app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

同じステージは `FROM ubuntu:26.04` に置き換えるだけで Ubuntu 26.04 でも機能します。

## **FAQ**

**「プレゼンテーションの保存が “Fontconfig head is null, check your fonts or fonts configuration” で停止します。何が足りませんか？」**  
フォントがありません。Java のフォントサポートがイメージ内にインストールされたフォントを検出できなかったためです。Debian や Ubuntu では `fonts-dejavu-core` のようなフォントパッケージをインストールしてください（[別のベースイメージの使用](#use-another-base-image) 参照）。他のフォントパッケージは [フォントの展開](/slides/ja/java/deploy-fonts/) に一覧があります。

**「アプリケーションが libfontmanager.so に対する UnsatisfiedLinkError で停止します。何が足りませんか？」**  
Java のフォントサポートに必要なネイティブライブラリが欠如しています。エラーメッセージに示される `libharfbuzz.so.0` などがロードできないことが原因です。これはディストリビューションのパッケージで Java をインストールしたときに推奨パッケージが除外された場合に起こります。[別のベースイメージの使用](#use-another-base-image) に記載のライブラリをインストールしてください。

**「PDF のフォントが PowerPoint と違うのはなぜですか？」**  
プレゼンテーションが使用しているフォントがイメージにインストールされていないため、Aspose.Slides が代替フォントで描画しています。アプリケーションの出力には置き換えられたフォントが一覧表示されます。[フォントの展開](/slides/ja/java/deploy-fonts/) でフォントのインストール方法やアプリケーションフォルダーからのロード方法を確認してください。

**「コンテナ内でアプリケーションが使用できるメモリはどれくらいですか？」**  
デフォルトでは Java はコンテナに割り当てられたメモリの 1/4 をヒープ上限とします。たとえば `docker run -m 1g` で起動した場合は約 250 MB が上限です。大容量のプレゼンテーションを処理するには `MaxRAMPercentage` オプションで比率を上げます。例: `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides` とすれば Java は起動時に「Picked up JAVA_TOOL_OPTIONS」行を出力します。

**「自分のマシンに JDK や Maven が必要ですか？」**  
必要ありません。ビルドステージは Maven イメージ内でアプリケーションをコンパイルします。Docker 以外でビルドや実行を行いたい場合のみ JDK と Maven が必要です（[インストール](/slides/ja/java/installation/) を参照）。