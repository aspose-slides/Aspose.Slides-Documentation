---
title: Javaでプレゼンテーション情報を取得および更新
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/java/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーションプロパティ
- ドキュメントプロパティ
- プロパティ取得
- プロパティ読み取り
- プロパティ変更
- プロパティ修正
- プロパティ更新
- PPTXを検査
- PPTを検査
- ODPを検査
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Javaを使用してPowerPointおよびOpenDocumentプレゼンテーションのスライド、構造、メタデータを調査し、より迅速な洞察とスマートなコンテンツ監査を実現します。"
---
## **概要**

この記事では、Aspose.Slides でプレゼンテーション情報を検査する方法を示します。ファイル全体をロードせずにプレゼンテーションの現在の形式を確認し、ドキュメント プロパティを読み取り、必要に応じてそれらのプロパティを更新する方法を説明します。

例は [PresentationInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationinfo/) および [DocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/documentproperties/) API を使用しており、プレゼンテーションのメタデータを操作する一般的な手順を示しています。

## **プレゼンテーション形式の確認**

プレゼンテーションを操作する前に、現在の形式（PPT、PPTX、ODP など）が何であるかを確認したい場合があります。

プレゼンテーションをロードせずに形式を確認できます。以下の Java コードをご覧ください。

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX形式

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT形式

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP形式
```

## **プレゼンテーション プロパティの取得**

以下の Java コードは、プレゼンテーション プロパティ（プレゼンテーションに関する情報）を取得する方法を示しています。

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

DocumentProperties クラスのプロパティをご覧になりたい場合があります。[DocumentProperties クラスのプロパティ](https://reference.aspose.com/slides/ja/java/com.aspose.slides/documentproperties/#DocumentProperties--)

## **プレゼンテーション プロパティの更新**

Aspose.Slides は、プレゼンテーション プロパティを変更できる [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) メソッドを提供しています。

以下に示すようなドキュメント プロパティを持つ PowerPoint プレゼンテーションがあるとします。

![PowerPoint プレゼンテーションの元のドキュメント プロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーション プロパティを編集する方法を示しています。

```java
import com.aspose.slides.*;
import java.util.Date;

String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

ドキュメント プロパティを変更した結果は以下のとおりです。

![変更後の PowerPoint プレゼンテーションのドキュメント プロパティ](output_properties.png)

## **便利なリンク**

プレゼンテーションとそのセキュリティ属性に関する詳細情報を得るには、以下のリンクが役立つ場合があります。

- [プレゼンテーションのパスワード保護](/slides/ja/java/password-protected-presentation/)
- [プレゼンテーションの書き込み保護](/slides/ja/java/write-protected-presentation/)

## **よくある質問**

フォントが埋め込まれているか、どのフォントが埋め込まれているかをどう確認できますか？

プレゼンテーション レベルで [embedded-font information](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) を確認し、そのエントリと [fonts actually used across content](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsmanager/#getFonts--) のセットを比較して、レンダリングに必要なフォントを特定します。

ファイルに非表示スライドが含まれているか、またその数をすぐに判断する方法はありますか？

[slide collection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidecollection/) を走査し、各スライドの [visibility flag](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slide/#getHidden--) を確認します。

カスタム スライド サイズや向きが使用されているか、既定値と異なるかを検出できますか？

はい。現在の [slide size](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getSlideSize--) と向きを標準プリセットと比較します。これにより、印刷やエクスポート時の挙動を予測できます。

チャートが外部データ ソースを参照しているかどうかをすばやく確認する方法はありますか？

はい。すべての [charts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/chart/) を走査し、[data source](https://reference.aspose.com/slides/ja/java/com.aspose.slides/chartdata/#getDataSourceType--) を確認して、データが内部かリンクベースか、壊れたリンクがあるかを判断します。

レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価する方法はありますか？

各スライドについてオブジェクト数を集計し、大きな画像、透過、影、アニメーション、マルチメディアを確認します。概算の複雑度スコアを付与して、パフォーマンス上のボトルネックとなり得るスライドをフラッグします。