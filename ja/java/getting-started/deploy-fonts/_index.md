---
title: Linux と Docker で Aspose.Slides for Java のフォントをデプロイ
linktitle: フォントのデプロイ
type: docs
weight: 155
url: /ja/java/deploy-fonts/
keywords:
- フォントのデプロイ
- フォントのインストール
- Docker のフォント
- Linux のフォント
- 欠落フォント
- フォント置換
- Microsoft コアフォント
- ttf-mscorefonts-installer
- カスタムフォント
- デフォルトフォント
- サーバー
- コンテナ
- PDF 変換
- プレゼンテーション
- Java
- Aspose.Slides
description: "Linux サーバーおよび Docker コンテナ上で Aspose.Slides for Java のフォントをデプロイします。代替されているフォントの確認、Debian、Ubuntu、Alpine でのフォントパッケージのインストール、独自のフォントファイルの追加、デフォルトフォントの設定方法をご紹介します。"
---
## **概要**

Aspose.Slides はプレゼンテーションをレンダリングするとき、利用可能なフォントでテキストを描画します。たとえばスライドを PDF や画像に変換する場合です。Windows デスクトップにはプレゼンテーションで使用されるフォントが通常インストールされていますが、Linux サーバーやコンテナにはフォントがほとんどないため、Aspose.Slides は代替フォントでテキストを描画します。代替フォントは文字形状や幅が異なるため、行の折り返しが変わったりテキストがシェイプからはみ出したり、代替フォントに存在しない文字は正しく描画されません。フォントがまったくインストールされていない場合、Java のフォントサポートが起動できず、Aspose.Slides はエラーで停止します。

本記事では、Aspose.Slides がどのフォントを代替しているかの確認方法、Debian、Ubuntu、Alpine Linux へのフォントのインストール方法、独自のフォントファイルの追加方法、フォントが見つからないときに使用するフォントの設定方法を示します。例は公式 Eclipse Temurin イメージ上の Docker で実行します（[Run Aspose.Slides for Java in Docker](/slides/ja/java/how-to-run-aspose-slides-in-docker/) を参照）。パッケージコマンドは Dockerfile の指示です。Linux サーバー上で実行する場合は、同じコマンドを root で実行してください。

フォント API 自体（プレゼンテーションへのフォント埋め込みやフォールバック・置換ルールなど）については、[PowerPoint Fonts](/slides/ja/java/powerpoint-fonts/) を参照してください。

## **代替されるフォントの確認方法**

以下の Maven プロジェクトは、現在の環境で Aspose.Slides が代替しているフォントをレポートします。*font-check* というフォルダーを作成し、下記のファイルをその中に配置してください。

*pom.xml* は [Run Aspose.Slides for Java in Docker](/slides/ja/java/how-to-run-aspose-slides-in-docker/#create-the-project) のものと同じですが、artifact ID と JAR ファイル名を *font-check* に変更しています：

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>font-check</artifactId>
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
        <finalName>font-check</finalName>
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

*src/main/java/FontCheck.java* は、各フォント名につきスライドにテキストボックスを 1 つ追加し、[setLatinFont](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) メソッドでフォントを設定します。フォント名はコマンドラインから取得します。引数がなければ、プログラムは Calibri、Arial、Times New Roman をチェックします。プログラムは Aspose.Slides がフォントを検索するフォルダー（[FontsLoader.getFontFolders](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#getFontFolders--)）を出力し、スライドを *output/fonts.pdf* にレンダリングし、[IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) が報告する代替情報を表示します。記事冒頭で説明する *fonts* フォルダーのロードと `DEFAULT_FONT` 変数の読み取りは、後述のオプションステップです。

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;

public class FontCheck {
    public static void main(String[] args) {
        // チェック対象のフォント: コマンドライン引数、または一般的な Office フォント 3 つ。
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // 作業ディレクトリの fonts フォルダーからフォントファイルをロードします（フォルダーが存在する場合）。
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // DEFAULT_FONT 環境変数で指定されたフォントを、フォントが見つからないテキストに使用します（設定されている場合）。
        LoadOptions loadOptions = new LoadOptions();
        String defaultFont = System.getenv("DEFAULT_FONT");
        if (defaultFont != null && !defaultFont.isEmpty()) {
            loadOptions.setDefaultRegularFont(defaultFont);
        }

        Set<String> fontFolders = new LinkedHashSet<>(Arrays.asList(FontsLoader.getFontFolders()));
        System.out.println("Font folders: " + String.join(", ", fontFolders));

        Presentation presentation = new Presentation(loadOptions);
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            for (int i = 0; i < fontNames.length; i++) {
                IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
                shape.getTextFrame().setText("This text is set in " + fontNames[i] + ".");
                shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData(fontNames[i]));
            }

            File outputFolder = new File("output");
            outputFolder.mkdirs();
            presentation.save(new File(outputFolder, "fonts.pdf").getPath(), SaveFormat.Pdf);

            List<FontSubstitutionInfo> substitutions = new ArrayList<>();
            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                substitutions.add(substitution);
            }

            if (substitutions.isEmpty()) {
                System.out.println("No font substitutions.");
            } else {
                System.out.println("Font substitutions:");
                for (FontSubstitutionInfo substitution : substitutions) {
                    System.out.println("  " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
                }
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

`getFontFolders` は同じフォルダーを複数回返すことがあるため、プログラムはそれらをセットに集めてから出力します。

*.dockerignore* はローカルのビルド結果をビルドコンテキストから除外します：

```text
target/
output/
```

*Dockerfile* は Maven イメージでプログラムをビルドし、Eclipse Temurin Java ランタイムイメージ上で実行します。このイメージにはすでに fontconfig と DejaVu フォントが含まれています。[Run Aspose.Slides for Java in Docker](/slides/ja/java/how-to-run-aspose-slides-in-docker/) で各指示の説明があります。

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

イメージをビルドしてチェックを実行します：

```bash
docker build -t font-check .
docker run --rm font-check
```

このイメージには DejaVu フォントしかないため、3 つのフォントすべてが DejaVu Sans に置き換えられます：

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

自分のプレゼンテーションのフォントを確認したい場合は、フォント名を引数として渡します。例: `docker run --rm font-check "Segoe UI" Consolas`。*output/fonts.pdf* をコンテナ外にコピーするには、[Copy the Output to Your Machine](/slides/ja/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine) の手順を使用してください。

## **Debian および Ubuntu へのフォントインストール**

### **Microsoft Core Fonts**

`ttf-mscorefonts-installer` パッケージは、Arial、Times New Roman、Courier New、Verdana、Georgia、Trebuchet MS など、Microsoft の Web 用コアフォントをダウンロードしてインストールします。これらのフォントは Microsoft のエンドユーザー使用許諾契約（EULA）に基づいて提供され、パッケージは EULA が受諾された後にのみインストールします。Docker ビルドではプロンプトに応答できないため、インストーラーは EULA を拒否しフォントをインストールせず、`apt-get install` は成功したと報告します。パッケージインストール前に **必ず** `debconf-set-selections` で EULA を受諾してください。後の指示で受諾しても意味がなく、パッケージはすでにインストール済みのため再度インストーラーは実行されません。

この指示は *Dockerfile* のランタイムステージの `FROM` 行直後に追加し、`USER` 指示の前に root で実行されるようにします：

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

イメージをビルドし、同じ 2 つのコマンドでチェックを再実行します。Arial と Times New Roman がインストールされました：

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Aspose.Slides が作成するプレゼンテーションのデフォルトフォントである Calibri はコアフォントに含まれないため、依然として代替されます。欠落フォントのデフォルト設定は [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts) を参照してください。

Ubuntu ベースの Eclipse Temurin イメージは `multiverse` コンポーネントを有効化しており、このコンポーネントに Microsoft Core Fonts が含まれます。Debian では同パッケージが `contrib` コンポーネントにあり、Debian イメージはデフォルトで有効化されていません。Debian ベースのランタイムステージ（[Use Another Base Image](/slides/ja/java/how-to-run-aspose-slides-in-docker/#use-another-base-image) 参照）では、同じ指示内で `contrib` を有効化します：

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **その他のフォントパッケージ**

Debian と Ubuntu には自由に使用できるフォントもパッケージ化されています。例：

| パッケージ | フォント |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans、DejaVu Serif、DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans、Serif、Mono（Arial、Times New Roman、Courier New と同じメトリクス） |
| `fonts-crosextra-carlito` | Carlito（Calibri と同じメトリクス） |
| `fonts-crosextra-caladea` | Caladea（Cambria と同じメトリクス） |

これらはランタイムステージの `RUN` 指示内で `apt-get install` すれば Microsoft Core Fonts と同様にインストールできます。Aspose.Slides for Java は Linux のフォント設定にあるエイリアスを使用しません。たとえば `fonts-liberation` をインストールしても、Arial のテキストは依然として一般的な代替フォントで描画されます。欠落フォントの代わりにメトリクス互換フォントを使用したい場合は、[default font](#set-a-default-font-for-missing-fonts) を設定するか、[font substitution rule](/slides/ja/java/font-substitution/) を追加してください。

## **独自のフォントファイルを追加する**

ディストリビューションにパッケージ化されていないフォント（組織独自のフォントやサーバーで使用許諾を得ているフォントなど）は、フォントファイルとして追加できます。たとえば *.ttf* ファイルを *font-check* フォルダー内の *fonts* フォルダーに置きます。以下の例は、Calibri と同じメトリクスを持つ Carlito フォントのファイルを使用します。Carlito は [Google Fonts](https://fonts.google.com/specimen/Carlito) からダウンロードできます。

### **システムフォントフォルダーにインストールする**

Aspose.Slides は `Font folders` 行に表示されたフォルダー内のフォントを読み取ります。イメージ内のすべてのアプリケーションでフォントを利用できるようにするには、*/usr/local/share/fonts*（ローカルインストール用フォルダー）にコピーします。この指示は Microsoft Core Fonts をインストールする `RUN` 指示の後、ランタイムステージの *Dockerfile* に追加します：

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

イメージを再ビルドし、Calibri と Carlito をチェックします：

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito はもはや代替されません：

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **アプリケーションフォルダーからロードする**

システムフォルダーにインストールする代わりに、アプリケーションと一緒にフォントを配置し、[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) でロードできます。これによりフォントは Aspose.Slides のみが使用でき、アプリケーションと共にデプロイされます。*FontCheck* はこの方法を取ります。コンテナ内の作業ディレクトリ（*/app*）に *fonts* フォルダーがある場合、プレゼンテーション作成前にそのフォルダーを `loadExternalFonts` に渡します。[Custom Font](/slides/ja/java/custom-font/) では、メモリからロードする方法など、他のフォント供給手段も紹介しています。

*Dockerfile* から `COPY fonts/ /usr/local/share/fonts/` 指示を削除し、*lib* フォルダーをコピーする指示の後に次の指示を追加します：

```dockerfile
COPY fonts/ ./fonts/
```

イメージを再ビルドし、同じ 2 つのコマンドでチェックを実行します。アプリケーションフォルダーがフォントフォルダー一覧に現れ、Carlito は引き続き代替されません：

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` はインストール済みフォントに追加しますが、Java のフォントサポートには最低でも 1 つのインストールフォントが必要です。フォントが全く無いイメージで実行すると、"Fontconfig head is null, check your fonts or fonts configuration" エラーで停止します。

## **欠落フォント用のデフォルトフォントを設定する**

フォントが欠落しているとき、Aspose.Slides は自動的に代替フォントを選択します。自分で指定したい場合は、[LoadOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/) の `setDefaultRegularFont` メソッドにフォント名を渡し、`Presentation` コンストラクターにオプションを渡します。*FontCheck* は `DEFAULT_FONT` 環境変数からフォント名を取得します。Carlito をロードした状態で、欠落フォントのデフォルトとして使用する例：

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

これにより Calibri が Carlito で描画され、文字幅が同じなので改行位置が保持されます：

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

デフォルトフォントはすべての欠落フォントを置き換えます。個別のマッピング（例: Arial → Liberation Sans、Calibri → Carlito）を行いたい場合は、[font substitution rules](/slides/ja/java/font-substitution/) を使用してください。ルールは描画結果に影響しますが、`getSubstitutions` には反映されないため、出力ファイル自体で確認してください。アジア文字向けには、[setDefaultAsianFont](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-) も呼び出す必要があります；詳しくは [Default Font](/slides/ja/java/default-font/) を参照してください。

## **Alpine Linux へのフォントインストール**

Alpine ベースの Eclipse Temurin イメージにも DejaVu フォントが含まれます。[Run on Alpine Linux](/slides/ja/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) でランタイムステージの説明があります。Microsoft Core Fonts を同様にインストールするには、*font-check* 用 Dockerfile のランタイムステージを次の内容に置き換えます：

```dockerfile
FROM eclipse-temurin:21-jre-alpine
RUN apk add --no-cache msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

`update-ms-fonts` は Debian / Ubuntu パッケージと同じ Microsoft Core Fonts をダウンロードしてインストールし、EULA の取り扱いも同様です。`fc-cache` は fontconfig のフォントキャッシュを更新します。イメージをビルドし、[Check Which Fonts Are Substituted](#check-which-fonts-are-substituted) の 2 つのコマンドでチェックを実行すると、次のように表示されます：

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

Alpine でも他の手順は同じです。*fonts* フォルダーを */usr/local/share/fonts* またはアプリケーションフォルダーにコピーし、`DEFAULT_FONT` を設定してデフォルトフォントを選択します。Alpine イメージには */usr/local/share/fonts* フォルダーがデフォルトで存在しないため、`COPY` 指示で作成した後にのみ `Font folders` 行に表示されます。

## **FAQ**

**サーバーで変換するとプレゼンテーションの見た目が変わるのはなぜですか？**

サーバーにプレゼンテーションで使用されているフォントが無いため、Aspose.Slides は文字幅が異なる代替フォントで描画します。*FontCheck* を使用して代替されたフォントを確認し、該当フォントをインストールするかアプリケーションフォルダーからロードしてください。

**ビルド時に ttf-mscorefonts-installer をインストールしましたが、Arial がまだ代替されています。理由は？**

パッケージインストール前に EULA を受諾していなかったため、インストーラーがフォントのインストールをスキップしました。`debconf-set-selections` コマンドを `apt-get install` より前に配置し、[Microsoft Core Fonts](#microsoft-core-fonts) と同様にイメージを再ビルドしてください。

**PDF を開くコンピューターにもフォントが必要ですか？**

不要です。この例では PDF にテキスト描画に使用したフォントが埋め込まれているため、どのコンピューターでも同じ見た目になります。フォントは Aspose.Slides がプレゼンテーションをレンダリングする環境でのみ必要です。