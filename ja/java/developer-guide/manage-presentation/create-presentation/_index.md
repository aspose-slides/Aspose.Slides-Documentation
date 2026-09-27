---
title: Java でプレゼンテーションを作成
linktitle: プレゼンテーションを作成
type: docs
weight: 10
url: /ja/java/create-presentation/
keywords:
- プレゼンテーションを作成
- 新しいプレゼンテーション
- PPT を作成
- 新しい PPT
- PPTX を作成
- 新しい PPTX
- ODP を作成
- 新しい ODP
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Java でプレゼンテーションを作成し、PPT、PPTX、ODP ファイルを生成し、OpenDocument のサポートを活用し、プログラムで保存して信頼性の高い結果を得られます。"
---
## **概要**

この記事では、Aspose.Slides でプレゼンテーションを作成し、最初のスライドにテキスト付きシェイプを追加し、結果を PPTX ファイルとして保存する方法を示します。既存のプレゼンテーションを開き、別の形式で保存する方法については、[プレゼンテーションを開く](/slides/ja/java/open-presentation/) と [プレゼンテーションを保存](/slides/ja/java/save-presentation/) を参照してください。最後の簡易 FAQ では、形式、テンプレート、スライドサイズ、単位、メモリ使用量、スレッド、ライセンス、デジタル署名、VBA のサポートに関する一般的な質問を取り上げています。

始める前に、Aspose の Maven リポジトリから Aspose.Slides for Java をプロジェクトに追加してください。Maven の設定や Linux に必要な追加手順については、[インストール](/slides/ja/java/installation/) を参照してください。

## **プレゼンテーションの作成**

Aspose.Slides for Java で最初から PowerPoint ファイルを作成するには、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスから開始します。コンストラクタは単一のスライドを持つ空のプレゼンテーションを提供し、シェイプ、テキスト、チャート、またはアプリケーションが必要とする任意のコンテンツを追加できる状態です。そのスライドを変更したり新しいスライドを追加したりした後、結果を PPTX、従来の PPT、または OpenDocument 形式で保存できます。

プレゼンテーションを作成し、最初のスライドにテキスト付きシェイプを配置するには、次の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。新しいプレゼンテーションにはすでに空のスライドが 1 つ含まれています。
2. そのスライドをインデックス 0 で取得します。取得は [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) が返すコレクションから行います。
3. [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) の `Cloud` タイプを [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) メソッドで追加し、[setText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#setText-java.lang.String-) でテキストを設定します。
4. [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) メソッドでプレゼンテーションを PPTX ファイルとして保存します。

以下の例は完全なプログラムです。[インストール](/slides/ja/java/installation/) の Maven プロジェクト内で、*src/main/java/HelloSlides.java* として保存し、`mvn compile exec:java` を実行してください。

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // プレゼンテーションを作成します。すでに空のスライドが1枚含まれています。
        Presentation presentation = new Presentation();
        try {
            // 最初のスライドを取得します。
            ISlide slide = presentation.getSlides().get_Item(0);

            // クラウドシェイプを追加し、テキストを設定します。
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

クラウドの左上隅はスライドの左端から 20 ポイント、上端から 20 ポイントの位置にあり、シェイプの幅は 200 ポイント、高さは 80 ポイントです。プログラムはクラウドとテキストを含むスライドが 1 枚の *new_presentation.pptx* を保存します。ライセンスがない場合、Aspose.Slides は保存するすべてのスライドに評価用の透かしを追加します；[ライセンス](/slides/ja/java/licensing/) を参照してください。

結果:

![新しいプレゼンテーション](new_presentation.png)

## **よくある質問**

### 新しいプレゼンテーションを保存できる形式は何ですか？

[PPTX, PPT, and ODP](/slides/ja/java/save-presentation/) に保存でき、また [PDF](/slides/ja/java/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/java/convert-powerpoint-to-xps/)、[HTML](/slides/ja/java/convert-powerpoint-to-html/)、[SVG](/slides/ja/java/render-a-slide-as-an-svg-image/) や [画像](/slides/ja/java/convert-powerpoint-to-png/) などにエクスポートできます。

### テンプレート（POTX/POTM）から開始し、通常の PPTX として保存できますか？

はい。テンプレートを読み込み、目的の形式で保存します。POTX/POTM/PPTM などの形式は [サポートされています](/slides/ja/java/supported-file-formats/) です。

### プレゼンテーション作成時にスライドのサイズ／アスペクト比を制御するには？

[スライドサイズ](/slides/ja/java/slide-size/) を設定します（4:3 や 16:9 のプリセット、またはカスタム寸法を含む）。そしてコンテンツのスケーリング方法を選択します。

### サイズや座標の単位は何ですか？

ポイント単位です。1 インチは 72 ユニットに相当します。

### 多数のメディアファイルを含む非常に大きなプレゼンテーションでメモリ使用量を削減するにはどうすればよいですか？

[BLOB管理戦略](/slides/ja/java/manage-blob/) を使用し、一時ファイルを活用してインメモリ格納を制限し、純粋なインメモリ ストリームよりもファイルベースのワークフローを優先します。

### プレゼンテーションを並列で作成／保存できますか？

同じ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) インスタンスに対して [複数スレッド](/slides/ja/java/multithreading/) から操作することはできません。スレッドまたはプロセスごとに別々の独立したインスタンスを実行してください。

### 評価用の透かしと制限を削除するには？

[ライセンスを適用](/slides/ja/java/licensing/) をプロセスごとに一度行います。ライセンス XML は変更せずに保持し、複数スレッドが関与する場合はライセンス設定を同期させる必要があります。

### 作成した PPTX にデジタル署名できますか？

はい。[デジタル署名](/slides/ja/java/digital-signature-in-powerpoint/)（追加と検証）はプレゼンテーションでサポートされています。

### 作成したプレゼンテーションでマクロ（VBA）はサポートされていますか？

はい。[VBAプロジェクトを作成/編集](/slides/ja/java/presentation-via-vba/) ができ、PPTM/PPSM などのマクロ有効ファイルとして保存できます。