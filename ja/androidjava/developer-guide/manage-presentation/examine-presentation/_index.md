---
title: Android でのプレゼンテーション情報の取得と更新
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/androidjava/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーション プロパティ
- ドキュメント プロパティ
- プロパティ取得
- プロパティ読み取り
- プロパティ変更
- プロパティ修正
- プロパティ更新
- PPTX の調査
- PPT の調査
- ODP の調査
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して PowerPoint および OpenDocument のプレゼンテーション内のスライド、構造、メタデータを調査し、迅速な洞察とスマートなコンテンツ監査を実現します。"
---

Aspose.Slides for Android via Java を使用すると、プレゼンテーションを調査してプロパティを確認し、その動作を理解できます。

{{% alert title="Info" color="info" %}} 

The [PresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo) and [DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/) classes contain the properties and methods used in operations here.

{{% /alert %}} 

## **プレゼンテーション形式の確認**

プレゼンテーションを操作する前に、現在の形式（PPT、PPTX、ODP など）を確認したい場合があります。

プレゼンテーションを読み込まずに形式をチェックできます。以下の Java コードをご参照ください:
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```


## **プレゼンテーション プロパティの取得**

この Java コードは、プレゼンテーション プロパティ（プレゼンテーションに関する情報）を取得する方法を示します:
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// 省略
```


DocumentProperties クラスの [properties under the DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) を参照してください。

## **プレゼンテーション プロパティの更新**

Aspose.Slides は、プレゼンテーション プロパティを変更できる [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) メソッドを提供しています。

以下に示すようなドキュメント プロパティを持つ PowerPoint プレゼンテーションがあるとします。

![Original document properties of the PowerPoint presentation](input_properties.png)

このコード例は、いくつかのプレゼンテーション プロパティを編集する方法を示します:
```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```


プロパティ変更の結果は以下のとおりです。

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **便利なリンク**

プレゼンテーションとそのセキュリティ属性に関する詳細情報については、以下のリンクが役立ちます。

- [Checking whether a Presentation is Encrypted](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Checking whether a Presentation is Write Protected (read-only)](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Checking whether a Presentation is Password Protected Before Loading it](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirming the Password Used to Protect a Presentation](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**フォントが埋め込まれているか、どのフォントかを確認する方法は？**

プレゼンテーション レベルで [embedded-font information](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) を探し、[fonts actually used across content](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getFonts--) と比較して、レンダリングに必須のフォントを特定します。

**ファイルに非表示スライドがあるかどうか、またその数をすばやく判断する方法は？**

[slide collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) を反復処理し、各スライドの [visibility flag](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#getHidden--) を確認します。

**カスタム スライド サイズや向きが使用されているか、デフォルトと異なるかを検出できるか？**

はい。現在の [slide size](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideSize--) と向きを標準設定と比較してください。これにより、印刷やエクスポート時の動作を予測できます。

**チャートが外部データ ソースを参照しているかどうかをすばやく確認する方法は？**

はい。すべての [charts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/) を走査し、[data source](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) を確認して、データが内部かリンクベースか、リンクが切れているかどうかを把握します。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価する方法は？**

各スライドごとにオブジェクト数を集計し、大きな画像、透明度、影、アニメーション、マルチメディアなどをチェックして、概算の複雑度スコアを付け、パフォーマンス上のホットスポットを特定します。