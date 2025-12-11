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
description: Java を使用して PowerPoint および OpenDocument プレゼンテーションのスライド、構造、メタデータを調査し、迅速な洞察と賢いコンテンツ監査を実現します。
---

Aspose.Slides for Android via Java は、プレゼンテーションを調べてプロパティを取得し、その動作を理解できるようにします。

{{% alert title="Info" color="info" %}} 
ここで使用する操作に必要なプロパティとメソッドは、[PresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo) と [DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/) クラスに含まれています。 
{{% /alert %}} 

## **プレゼンテーション形式の確認**

プレゼンテーションを操作する前に、現在の形式（PPT、PPTX、ODP など）が何かを確認したくなることがあります。

プレゼンテーションを読み込まずに形式を確認できます。次の Java コードをご覧ください。
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```


## **プレゼンテーションプロパティの取得**

この Java コードは、プレゼンテーションのプロパティ（プレゼンテーションに関する情報）の取得方法を示しています。
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// 省略
```


DocumentProperties クラスの [プロパティ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) を確認したい場合があります。

## **プレゼンテーションプロパティの更新**

Aspose.Slides は、プレゼンテーションプロパティを変更できる [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) メソッドを提供します。

以下に示すようなドキュメントプロパティを持つ PowerPoint プレゼンテーションがあるとします。

![PowerPoint プレゼンテーションの元のドキュメントプロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーションプロパティを編集する方法を示しています。
```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```


ドキュメントプロパティを変更した結果は以下の通りです。

![PowerPoint プレゼンテーションの変更後ドキュメントプロパティ](output_properties.png)

## **役立つリンク**

プレゼンテーションおよびそのセキュリティ属性に関する詳細情報は、以下のリンクが役立ちます。

- [プレゼンテーションが暗号化されているか確認する](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [プレゼンテーションが書き込み保護（読み取り専用）されているか確認する](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [ロード前にプレゼンテーションがパスワード保護されているか確認する](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [プレゼンテーションを保護するために使用されたパスワードを確認する](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **よくある質問**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかどうかはどう確認できますか？**  
プレゼンテーション レベルで [埋め込みフォント情報](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) を確認し、次に [実際にコンテンツで使用されているフォント](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getFonts--) と比較して、レンダリングに重要なフォントを特定します。

**ファイルに非表示スライドがあるかどうか、またその数はどうやってすばやく確認できますか？**  
[スライド コレクション](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) を反復処理し、各スライドの [表示フラグ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#getHidden--) を確認します。

**カスタム スライド サイズと向きが使用されているか、デフォルトと異なるかどうかを検出できますか？**  
はい。現在の [スライド サイズ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideSize--) と向きを標準のプリセットと比較します。これにより、印刷やエクスポート時の動作を予測できます。

**チャートが外部データソースを参照しているかどうかをすばやく確認する方法はありますか？**  
はい。すべての [チャート](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/) を走査し、各 [データ ソース](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) を確認して、データが内部かリンクベースか、破損したリンクがあるかどうかを記録します。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドをどのように評価できますか？**  
各スライドについてオブジェクト数を集計し、大きな画像、透明度、影、アニメーション、マルチメディアなどを確認します。大まかな複雑度ス�アを付けて、パフォーマンス上のホットスポットの可能性を示します。