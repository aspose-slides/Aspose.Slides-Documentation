---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
type: docs
weight: 20
url: /ja/java/
keywords:
- 文書
- プレゼンテーション処理
- プレゼンテーション変換
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "ここから開始してください: Aspose.Slides for Java をインストールし、最初のプレゼンテーションを作成し、共通タスク、デプロイ、API リファレンスに関するガイドを見つけましょう。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java は、Microsoft PowerPoint を使用せずに、Java アプリケーションで PowerPoint および OpenDocument のプレゼンテーションを作成、読み取り、編集、変換するためのクラスライブラリです。

PPT、PPTX、PPS、POT、ODP をマクロ対応やテンプレート形式を含めて読み書きでき、PDF、XPS、HTML、SVG、TIFF、Markdown、画像へエクスポートします。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>はじめに</b></p>
<hr>
<p>開始</p>
<ul>
<li><a href="/slides/ja/java/installation/">インストール</a></li>
<li><a href="/slides/ja/java/create-presentation/">最初のプレゼンテーションを作成</a></li>
<li><a href="/slides/ja/java/system-requirements/">システム要件</a></li>
<li><a href="/slides/ja/java/getting-started/">はじめにガイド</a></li>
</ul>
<p>評価</p>
<ul>
<li><a href="/slides/ja/java/supported-file-formats/">対応ファイル形式</a></li>
<li><a href="/slides/ja/java/features-overview/">機能概要</a></li>
<li><a href="/slides/ja/java/evaluate-aspose-slides/">トライアルの制限</a></li>
<li><a href="/slides/ja/java/licensing/">ライセンス</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slidesで構築</b></p>
<hr>
<p>共通タスク</p>
<ul>
<li><a href="/slides/ja/java/open-presentation/">プレゼンテーションを開く</a></li>
<li><a href="/slides/ja/java/save-presentation/">プレゼンテーションを保存</a></li>
<li><a href="/slides/ja/java/convert-powerpoint-to-pdf/">PDFに変換</a></li>
<li><a href="/slides/ja/java/convert-slide/">スライドを画像としてレンダリング</a></li>
<li><a href="/slides/ja/java/manage-text/">テキストとシェイプを編集</a></li>
</ul>
<p>Slidesワークフロー</p>
<ul>
<li><a href="/slides/ja/java/powerpoint-charts/">チャート</a></li>
<li><a href="/slides/ja/java/powerpoint-animation/">アニメーション</a></li>
<li><a href="/slides/ja/java/manage-media-files/">音声と動画</a></li>
<li><a href="/slides/ja/java/presentation-design/">スライドデザイン</a></li>
<li><a href="/slides/ja/java/merge-presentation/">プレゼンテーションの結合</a></li>
</ul>
<p>例</p>
<ul>
<li><a href="/slides/ja/java/examples/">スライド要素別の例</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">GitHub の例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>デプロイとサポート</b></p>
<hr>
<p>デプロイ</p>
<ul>
<li><a href="/slides/ja/java/system-requirements/#linux">Linux の前提条件</a></li>
<li><a href="/slides/ja/java/how-to-run-aspose-slides-in-docker/">Docker で実行</a></li>
<li><a href="/slides/ja/java/deploy-fonts/">フォント</a></li>
<li><a href="/slides/ja/java/security/">セキュリティ</a></li>
</ul>
<p>リファレンス</p>
<ul>
<li><a href="https://reference.aspose.com/slides/ja/java/">API リファレンス</a></li>
<li><a href="https://releases.aspose.com/slides/ja/java/release-notes/">リリースノート</a></li>
<li><a href="/slides/ja/java/known-issues/">既知の問題</a></li>
<li><a href="/slides/ja/java/api-limitations/">出力メタデータの制限</a></li>
<li><a href="https://releases.aspose.com/slides/ja/java/">ダウンロード</a></li>
</ul>
<p>サポート</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/ja/11">無料サポートフォーラム</a></li>
<li><a href="https://helpdesk.aspose.com/">有料サポートヘルプデスク</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **最初のプレゼンテーション**

Aspose.Slides for Java は Aspose の独自 Maven リポジトリに公開されており、Maven Central にはありません。Maven プロジェクト用のフォルダーを作成し、その中に *pom.xml* を保存します。このファイルはリポジトリを宣言し、ライブラリを追加し、実行するクラスを指定します。

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-slides</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <exec.mainClass>HelloSlides</exec.mainClass>
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
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
        </plugins>
    </build>
</project>
```

このコードを *src/main/java/HelloSlides.java* に保存します：

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // プレゼンテーションを作成します。すでに空のスライドが1枚含まれています。
        Presentation presentation = new Presentation();
        try {
            // 最初のスライドを取得します。
            ISlide slide = presentation.getSlides().get_Item(0);

            // 雲形状を追加し、テキストを設定します。
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // プレゼンテーションを PPTX ファイルとして保存します。
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

次に、JDK 11 以降と Apache Maven がインストールされている状態で、プロジェクトフォルダー内で次のコマンドを実行します：

```bash
mvn compile exec:java
```

プログラムはプロジェクトフォルダーに *new_presentation.pptx* を保存し、テキスト付きの雲形状を持つスライドを 1 枚作成します。Linux では fontconfig と少なくとも 1 つのフォントがインストールされている必要があります；[インストール](/slides/ja/java/installation/#linux) を参照してください。ライセンスがない場合、保存されたファイルには評価用の透かしが付与されます — [ライセンス](/slides/ja/java/licensing/) を参照してください。プレゼンテーションの作成と内容の追加に関するその他の方法については、[プレゼンテーションの作成](/slides/ja/java/create-presentation/) をご覧ください。