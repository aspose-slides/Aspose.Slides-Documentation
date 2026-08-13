---
title: Aspose.Slides for Java 14.5.0 のパブリック API と下位互換性のない変更
linktitle: Aspose.Slides for Java 14.5.0
type: docs
weight: 40
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のパブリック API の更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---
{{% alert color="info" %}} 

このページでは、Aspose.Slides for Java 14.5.0 APIで導入されたすべての[added](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) クラス、メソッド、プロパティ等、また新しい[restrictions](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) と他の[changes](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) を一覧表示します。

{{% /alert %}} 
## **パブリック API と下位互換性のない変更**
### **追加されたクラスとメソッド**
#### **Aspose.Slides.IPresentationInfo インターフェイスと PresentationInfo クラスを追加**
プレゼンテーションに関する情報を表します。

メソッド Boolean isEncrypted() は、プレゼンテーションが暗号化されている場合は True を、そうでない場合は False を取得します。

メソッド LoadFormat getLoadFormat() は、プレゼンテーションの種類を取得します。
#### **Aspose.Slides.IShape.isGrouped() メソッドを追加**
メソッド Aspose.Slides.IShape.isGrouped() は、シェイプがグループ化されているかどうかを判定します。
#### **Aspose.Slides.IShape.getParentGroup() メソッドを追加**
メソッド Aspose.Slides.IShape.getParentGroup() は、シェイプがグループ化されている場合は親の GroupShape オブジェクトを返します。そうでない場合は null を返します。
#### **Aspose.Slides.IShapeCollection.addGroupShape() メソッドを追加**
メソッド Aspose.Slides.IShapeCollection.addGroupShape() は新しい GroupShape を作成し、コレクションの末尾に追加します。

新しいシェイプが GroupShape に追加されると、GroupShape のフレームサイズと位置はコンテンツに合わせて調整されます。
#### **Aspose.Slides.IShapeCollection.clear() メソッドを追加**
メソッド Aspose.Slides.IShapeCollection.clear() は、コレクション内のすべてのシェイプを削除します。
#### **Aspose.Slides.IShapeCollection.insertGroupShape(int) メソッドを追加**
メソッド Aspose.Slides.IShapeCollection.insertGroupShape(int) は新しい GroupShape を作成し、指定したインデックスに挿入します。

GroupShape のフレームサイズと位置は、GroupShape に新しいシェイプが追加されるとコンテンツに合わせて調整されます。
#### **IPresentationFactory.getPresentationInfo(string file)、IPresentatoinFactory.getPresentationInfo(InputStream stream) メソッドを追加**
これらのメソッドにより、開発者はプレゼンテーション全体を読み込まずに、プレゼンテーションファイル/ストリームに関する情報を取得できます。
#### **IPresentationFactory PresentationFactory.getInstance() メソッドを追加**
インスタンス化せずにファクトリ機能を利用できるようにします。
### **制限事項**
#### **IShape.getFrame() の未定義値使用に対する制限が追加されました**
未定義のフレームを IShape.setFrame(IShapeFrame) に割り当てようとするコードは、一般的なケース（特に親の GroupShape が他の {{GroupShape}} に複数階層でネストされている場合）では意味がありません。例として：

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // ArgumentException をスローします: フレーム値は定義されている必要があります。
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

または

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // ArgumentException をスローします: x、y、幅、そして高さの値は定義されている必要があります。
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

このようなコードは不明瞭な状況を招く可能性があります。そのため、IShape.Frame の未定義値使用に対する制限が追加されました。x、y、width、height、flipH、flipV、rotationAngle の値は必ず定義されている必要があります（Float.NaN または NullableBool.NotDefined ではいけません）。上記の例コードは現在 ArgumentException をスローします。

これは以下の使用例に適用されます：

``` java
// IShape.setFrame(IShapeFrame) に渡されるフレームには未定義の値を含められません.

// 以下の IShapeCollection メソッドの x、y、幅、そして高さ パラメータは
// Float.NaN にすることもできません.
//:

//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

ただし、IShape.getRawFrame() のフレームは未定義であることが許容されます。シェイプがプレースホルダーにリンクされている場合、未定義のシェイプフレーム値は親プレースホルダーシェイプから上書きされます。シェイプに親プレースホルダーシェイプが存在しない場合、IShape.getRawFrame() に基づいて有効フレームを評価するときにデフォルト値が使用されます。デフォルト値は x、y、width、height、flipH、flipV、rotationAngle がそれぞれ 0 と NullableBool.False です。例として：

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // シェイプはプレースホルダーにリンクされています。
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // 今、このシェイプはプレースホルダーから x、y、height、flipH、flipV の値を継承します
    // そして width = 100 と rotationAngle = 0 を上書きします。
} finally {
    if (pres != null) pres.dispose();
}
```
### **変更されたプロパティ**
#### **Aspose.Slides.IShapeCollection.getParent() メソッドの型と名前が変更されました**
Aspose.Slides.IShapeCollection.Parent プロパティの型は、ISlideComponent から新しい IGroupShape インターフェイスに変更されました。IGroupShape インターフェイスは ISlideComponent の派生なので、既存のコードは変更不要です。

Aspose.Slides.IShapeCollection.getParent() メソッドの名前は、getParent から getParentGroup() に変更されました。
#### **Aspose.Slides.IShapeFrame.getFlipH() および .getFlipV() メソッドの型が変更されました**
Aspose.Slides.IShapeFrame.getFlipH() メソッドの型は bool から NullableBool に変更されました。

IShape.getFrame() メソッドは、すべてのプロパティに有効な値が定義された IShapeFrame の実体を返します。

IShape.getRawFrame() メソッドは、各プロパティが未定義（特に FlipH または FlipV が NullableBool.NotDefined になる可能性がある）になる可能性のある IShapeFrame インスタンスを返します。