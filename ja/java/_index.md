---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
type: docs
weight: 20
url: /ja/java/
keywords:
- ドキュメント
- プレゼンテーション処理
- プレゼンテーション変換
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "ここから始めてください: Aspose.Slides for Java をインストールし、最初のプレゼンテーションを作成し、共通タスクのガイド、API リファレンス、サポートを見つけましょう。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java は、Microsoft PowerPoint を使用せずに、Java アプリケーションで PowerPoint と OpenDocument のプレゼンテーションを作成、読み取り、編集、変換するためのクラス ライブラリです。

マクロ対応やテンプレート バリエーションを含む PPT、PPTX、PPS、POT、ODP を読み込みおよび保存し、PDF、XPS、HTML、SVG、TIFF、Markdown、画像へエクスポートします。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>開始する</b></p>
<hr>
<p>開始ガイド</p>
<ul>
<li><a href="/slides/ja/java/installation/">インストール</a></li>
<li><a href="/slides/ja/java/create-presentation/">最初のプレゼンテーションを作成する</a></li>
<li><a href="/slides/ja/java/getting-started/">開始ガイド</a></li>
</ul>
<p>評価</p>
<ul>
<li><a href="/slides/ja/java/supported-file-formats/">サポートされているファイル形式</a></li>
<li><a href="/slides/ja/java/evaluate-aspose-slides/">試用版の制限</a></li>
<li><a href="/slides/ja/java/licensing/">ライセンス情報</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides で構築</b></p>
<hr>
<p>共通タスク</p>
<ul>
<li><a href="/slides/ja/java/open-presentation/">プレゼンテーションを開く</a></li>
<li><a href="/slides/ja/java/save-presentation/">プレゼンテーションを保存する</a></li>
<li><a href="/slides/ja/java/convert-powerpoint-to-pdf/">PDF に変換する</a></li>
<li><a href="/slides/ja/java/convert-slide/">スライドを画像としてレンダリングする</a></li>
<li><a href="/slides/ja/java/manage-text/">テキストと図形を編集する</a></li>
</ul>
<p>Slides ワークフロー</p>
<ul>
<li><a href="/slides/ja/java/powerpoint-charts/">チャート</a></li>
<li><a href="/slides/ja/java/powerpoint-animation/">アニメーション</a></li>
<li><a href="/slides/ja/java/manage-media-files/">音声と動画</a></li>
<li><a href="/slides/ja/java/presentation-design/">スライド デザイン</a></li>
<li><a href="/slides/ja/java/merge-presentation/">プレゼンテーションを結合する</a></li>
</ul>
<p>サンプル</p>
<ul>
<li><a href="/slides/ja/java/examples/">スライド要素別サンプル</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">GitHub のサンプル</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>リファレンス &amp; サポート</b></p>
<hr>
<p>リファレンス</p>
<ul>
<li><a href="https://reference.aspose.com/slides/java/">API リファレンス</a></li>
<li><a href="https://releases.aspose.com/slides/java/release-notes/">リリース ノート</a></li>
<li><a href="/slides/ja/java/known-issues/">既知の問題</a></li>
<li><a href="https://releases.aspose.com/slides/java/">ダウンロード</a></li>
</ul>
<p>サポート</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">無料サポート フォーラム</a></li>
<li><a href="https://helpdesk.aspose.com/">有料サポート ヘルプデスク</a></li>
</ul>
</div>
</div>

------

## **最初のプレゼンテーション**

Aspose.Slides for Java は Maven Central ではなく Aspose の独自 Maven リポジトリで公開されています。Maven プロジェクト用のフォルダーを作成し、*pom.xml* をその中に保存します。このファイルはリポジトリを宣言し、ライブラリを追加し、実行するクラスを指定します：

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

このコードを *src/main/java/HelloSlides.java* として保存します：

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // プレゼンテーションを作成します。すでに空のスライドが1枚含まれています。
        Presentation presentation = new Presentation();
        try {
            // 最初のスライドを取得します。
            ISlide slide = presentation.getSlides().get_Item(0);

            // 雲形状を追加し、その中にテキストを設定します。
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

次に、JDK 11 以降と Apache Maven がインストールされている状態で、プロジェクト フォルダー内で次のコマンドを実行します：

```bash
mvn compile exec:java
```

このプログラムはプロジェクト フォルダーに *new_presentation.pptx* を保存し、テキスト付きの雲形状を持つスライドが 1 枚含まれます。Linux では fontconfig と少なくとも 1 つのフォントがインストールされている必要があります；[インストール](/slides/ja/java/installation/#linux) を参照してください。ライセンスがない場合、保存されたファイルには評価用の透かしが付加されます — [ライセンス情報](/slides/ja/java/licensing/) を参照してください。プレゼンテーションの作成や内容の設定の詳細については、[プレゼンテーションの作成](/slides/ja/java/create-presentation/) をご覧ください。