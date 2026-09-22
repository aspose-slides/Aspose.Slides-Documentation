---
title: Android でプレゼンテーション情報を取得および更新する
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/androidjava/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーションプロパティ
- ドキュメントプロパティ
- プロパティ取得
- プロパティ読み取り
- プロパティ変更
- プロパティ修正
- プロパティ更新
- PPTX の検査
- PPT の検査
- ODP の検査
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して PowerPoint および OpenDocument プレゼンテーションのスライド、構造、メタデータを調査し、より迅速な洞察と賢いコンテンツ監査を実現します。"
---
## **概要**

Aspose.Slides は、プレゼンテーションの形式を識別し、完全なプレゼンテーションオブジェクトモデルを作成せずにドキュメントメタデータを読み取ることができます。これは、ファイルを分類したり、インベントリを作成したり、プレゼンテーションの内容を読み込んで処理するかどうかを決定する前にプロパティを検査したりする場合に便利です。

この記事では、[PresentationFactory](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationfactory/) と [IPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/) を使用した軽量な検査と、[IDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/) を使用したターゲット更新を示します。

## **プレゼンテーション形式の確認**

既にロード済みのプレゼンテーションがある場合は、ロード後の検出とレガシー PPT、PPS、POT ストリームの制限については、[Determine the Original Presentation Format](/slides/ja/androidjava/detect-presentation-source-format/) を参照してください。

ファイルを検査するには、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) を使用し、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) インスタンスを作成せずに行います。[IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) メソッドは、PPTX、PPT、ODP などの検出された形式を報告します。

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **軽量なプレゼンテーションインベントリの構築**

多数のプレゼンテーションファイルを処理する場合、検証、インデックス付け、またはドキュメント管理システムのためにコンパクトなインベントリが必要になることがあります。このシナリオでは、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) を使用して [IPresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/) オブジェクトを取得し、次に [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) を呼び出してドキュメントメタデータを読み取ります。このアプローチは、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) インスタンスを作成せず、完全なプレゼンテーションオブジェクトモデルを走査する必要もありません。

[IDocumentProperties] が提供する拡張プロパティは、以下のインベントリ値を提供します。

| メソッド | インベントリ値 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | スライドの総数。 |
| [getHiddenSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | 非表示スライドの数。 |
| [getNotes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | ノートを含むスライドの数。 |
| [getParagraphs](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | 利用可能な場合の段落の総数。 |
| [getWords](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | 単語の総数。 |
| [getMultimediaClips](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | 音声および動画クリップの総数。 |

次の例では、[Presentation] オブジェクトを作成せずにこれらの値を読み取り、コンパクトなインベントリを出力します。また、[getHeadingPairs] と [getTitlesOfParts] を組み合わせて、フォント、テーマ、スライドタイトルなどのコンテンツグループを表示します。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

各 [IHeadingPair] はグループ名とそのグループ内の項目数を提供します。[IDocumentProperties.getTitlesOfParts] はフラットで順序付けされた配列を返すため、各見出しペアで指定された連続したタイトルの数だけ取得します。

### **保存されたメタデータと形式の制限**

[IPresentationInfo.readDocumentProperties] が返すインベントリプロパティは、ソースドキュメントで利用可能なメタデータを反映しています。Aspose.Slides はこの呼び出しのためにプレゼンテーションオブジェクトモデルをロードして走査し、これらの値を再計算しません。欠落しているプロパティはデフォルト値で表され、最後にファイルを保存したアプリケーションがドキュメントプロパティを更新しなかった場合、保存された値は古くなる可能性があります。

- **PPTX:** この形式は、スライド、ノート、非表示スライド、段落、単語、マルチメディアのカウント、および見出しペアとパートタイトルの拡張ドキュメントプロパティを提供します。利用可能性は、ドキュメント作成者が書き込んだプロパティに依存します。
- **PPT:** バイナリ形式は対応するドキュメントサマリープロパティを保存できます。プロパティが存在しない場合やドキュメント作成者が更新していない場合、Aspose.Slides はスライドから計算するのではなく、保存された値またはデフォルト値を返します。
- **ODP:** OpenDocument メタデータは、ページ、段落、単語数などの一般的なドキュメント統計情報を提供しますが、これらの値はすべての PowerPoint 固有の拡張プロパティに対応しているわけではありません。非表示スライド、ノートスライド、マルチメディア、見出しペア、パートタイトルのメタデータは利用できない場合があり、インベントリプロパティはデフォルト値を返すことがあります。ゼロ値や空配列を、対応するコンテンツが存在しないことの決定的な証拠として扱わないでください。

インベントリや予備的なチェックには軽量メタデータアプローチを使用してください。結果がメモリ内の変更を反映する必要がある場合や、実際のプレゼンテーションコンテンツを検証する必要がある場合は、プレゼンテーションをロードしてライブオブジェクトモデルを検査してください。

## **プレゼンテーションプロパティの更新**

[IPresentationInfo.readDocumentProperties] が返すプロパティは、[Presentation] インスタンスを作成せずに変更することもできます。[IPresentationInfo.updateDocumentProperties] で変更を適用し、次に [IPresentationInfo.writeBindedPresentation] でバインドされたプレゼンテーションを書き出します。

次の画像は、元のドキュメントプロパティを示しています。

![PowerPoint プレゼンテーションの元のドキュメントプロパティ](input_properties.png)

次の例では、タイトルと最終保存時刻を変更し、結果を新しいファイルに書き込みます。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

次の画像は、更新されたドキュメントプロパティを示しています。

![PowerPoint プレゼンテーションの変更されたドキュメントプロパティ](output_properties.png)

## **便利なリンク**

関連するセキュリティチェックや保護設定については、以下の記事をご覧ください。

- [プレゼンテーションのパスワード保護](/slides/ja/androidjava/password-protected-presentation/)
- [プレゼンテーションの書き込み保護](/slides/ja/androidjava/write-protected-presentation/)

## **よくある質問**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認するにはどうすればよいですか？**

プレゼンテーションをロードし、[Presentation.getFontsManager] を使用します。[IFontsManager.getEmbeddedFonts] を呼び出して埋め込まれたフォントを取得し、[IFontsManager.getFonts] を呼び出してプレゼンテーションで使用されているフォントを取得します。この2つの結果を比較して、レンダリングに必要だが埋め込まれていないフォントを見つけます。

**ファイルに非表示スライドがあるかどうか、そしてその数をすばやく確認するには？**

保存されているドキュメントメタデータで十分な場合は、[PresentationFactory.getPresentationInfo] と [IPresentationInfo.readDocumentProperties] を通じて [IDocumentProperties.getHiddenSlides] を読み取ります。これは軽量インベントリに適しています。プレゼンテーションがメモリ上で変更されている場合、保存されたメタデータが欠落または古くなる可能性がある、またはライブ値を確認する必要がある場合は、[Presentation.getSlides] を反復し、各スライドの [ISlide.getHidden] メソッドを調べます。

**カスタムスライドサイズと向きが使用されているか、既定と異なるかを検出できますか？**

はい。プレゼンテーションをロードし、[Presentation.getSlideSize] を呼び出します。[ISlideSize.getType]、[ISlideSize.getSize]、[ISlideSize.getOrientation] を使用して、現在の設定を期待されるプリセットやサイズと比較します。

**チャートが外部データソースを参照しているかどうかをすばやく確認する方法はありますか？**

はい。各 [Chart] を見つけ、[IChartData.getDataSourceType] を呼び出します。外部のワークブックの場合は、[IChartData.getExternalWorkbookPath] を呼び出します。データソースのタイプとパスが外部参照を示しますが、対象が利用可能かどうかを確認するには別途リソースチェックが必要です。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価するにはどうすればよいですか？**

単一の複雑さプロパティは存在しません。[Presentation.getSlides] と各スライドの [IBaseSlide.getShapes] コレクションを走査します。シェイプ数や大きな画像、エフェクト、アニメーション、マルチメディアの有無をスクリーニングの指標として使用し、スライドを確実なパフォーマンスボトルネックとみなす前に、代表的なレンダリングまたはエクスポートを測定します。