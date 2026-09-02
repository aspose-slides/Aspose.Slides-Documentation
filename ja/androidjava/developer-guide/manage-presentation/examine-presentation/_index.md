---
title: Android でプレゼンテーション情報を取得および更新
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/androidjava/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーション プロパティ
- ドキュメント プロパティ
- プロパティの取得
- プロパティの読み取り
- プロパティの変更
- プロパティの修正
- プロパティの更新
- PPTX の調査
- PPT の調査
- ODP の調査
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して PowerPoint および OpenDocument のプレゼンテーションのスライド、構造、メタデータを調査し、より迅速な洞察と賢明なコンテンツ監査を実現します。"
---
## **概要**

この記事では、Aspose.Slidesでプレゼンテーション情報を検査する方法を示します。ファイル全体をロードせずにプレゼンテーションの現在の形式を判定し、ドキュメントプロパティを読み取り、必要に応じてそれらのプロパティを更新する方法を説明します。

例は[PresentationInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationinfo/)および[DocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/documentproperties/) APIを基にしており、プレゼンテーションのメタデータを操作する典型的な操作を示しています。

## **プレゼンテーション形式の確認**

プレゼンテーションを操作する前に、現在の形式（PPT、PPTX、ODP、その他）が何であるかを確認したくなることがあります。

プレゼンテーションをロードせずに形式を確認できます。このJavaコードをご覧ください：

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **プレゼンテーションプロパティの取得**

このJavaコードは、プレゼンテーションプロパティ（プレゼンテーションに関する情報）を取得する方法を示します：

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

DocumentPropertiesクラスの[プロパティ](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--)をご覧になることができます。

## **プレゼンテーションプロパティの更新**

Aspose.Slidesは、プレゼンテーションプロパティを変更できる[PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)メソッドを提供しています。

以下に示すドキュメントプロパティを持つPowerPointプレゼンテーションがあるとしましょう。

![PowerPointプレゼンテーションの元のドキュメントプロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーションプロパティを編集する方法を示します：

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

ドキュメントプロパティの変更結果は以下の通りです。

![PowerPointプレゼンテーションの変更されたドキュメントプロパティ](output_properties.png)

## **便利なリンク**

プレゼンテーションとそのセキュリティ属性に関する詳細情報を得るには、以下のリンクが役立つでしょう：

- [プレゼンテーションのパスワード保護](/slides/ja/androidjava/password-protected-presentation/)
- [プレゼンテーションの書き込み保護](/slides/ja/androidjava/write-protected-presentation/)

## **FAQ**

**フォントが埋め込まれているか、どのフォントかを確認する方法は？**

プレゼンテーションレベルで[埋め込みフォント情報](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--)を確認し、それらのエントリを[実際にコンテンツ全体で使用されているフォント](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsmanager/#getFonts--)のセットと比較して、レンダリングに必須のフォントを特定します。

**ファイルに非表示スライドがあるか、またその数をすぐに確認する方法は？**

[スライドコレクション](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidecollection/)を反復し、各スライドの[可視性フラグ](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slide/#getHidden--)をチェックします。

**カスタムスライドサイズや向きが使用されているか、デフォルトと異なるかを検出できますか？**

はい。現在の[スライドサイズ](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getSlideSize--)と向きを標準のプリセットと比較します。これにより、印刷やエクスポート時の挙動を予測できます。

**チャートが外部データソースを参照しているかすぐに確認する方法はありますか？**

はい。すべての[チャート](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/chart/)を走査し、[データソース](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/chartdata/#getDataSourceType--)を確認して、データが内部かリンクベースか、壊れたリンクがあるかを把握します。

**レンダリングやPDFエクスポートを遅くする可能性のある「重い」スライドを評価する方法は？**

各スライドについてオブジェクト数を集計し、大きな画像、透明度、影、アニメーション、マルチメディアなどを確認します。おおまかな複雑度スコアを割り当て、パフォーマンスのボトルネックになり得るスライドをフラグ付けします。