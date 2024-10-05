---
title: .NET向けAspose.Slidesの公開APIと後方互換性のない変更点 14.3.0
type: docs
weight: 50
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
---

## **公開APIと後方互換性のない変更点**
### **Aspose.Slides.ShapeThumbnailBounds列挙型とAspose.Slides.IShape.GetThumbnail()メソッドの追加**
GetThumbnail()およびGetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)メソッドは、別々の形状サムネイルを作成するために使用されます。ShapeThumbnailBounds列挙型は、可能な形状サムネイル境界タイプを定義します。
### **Aspose.Slides.IShapeにUniqueIdプロパティが追加されました**
Aspose.Slides.IShape.UniqueIdプロパティは、プレゼンテーションスコープ内の形状識別子を取得します。これらの一意の識別子は、形状のカスタムタグに保存されます。
### **IChartCategoryLevelsManagerのSetGroupingItemメソッドのシグネチャが変更されました**
IChartCategoryLevelsManagerメソッドのシグネチャ

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

は廃止され、次のシグネチャに置き換えられました。

``` csharp

 void SetGroupingItem(int level, object value);

``` 

これにより、次のような呼び出しは

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

次のような呼び出しに変更する必要があります。

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

IChartDataCell型の値ではなく、"Group 1"のような値をSetGroupingItemに渡します。定義されたワークシート、行、および列でIChartDataCellを構築することは、いくつかの要件を満たす必要があり、SetGroupingItem(int, object)メソッドにカプセル化されています。
### **Aspose.Slides.IBaseSlideインターフェイスにSlideIdプロパティが追加されました**
SlideIdプロパティは、一意のスライド識別子を取得します。
### **ISlideShowTransitionにSoundNameプロパティが追加されました**
読み書き可能な文字列。遷移の音のための人間が読める名前を指定します。Soundプロパティに割り当てる必要があり、音の名前を取得または設定します。この名前は、遷移音を手動で設定するときにPowerPointユーザーインターフェイスに表示されます。Soundプロパティが割り当てられていない場合、PptxExceptionをスローする可能性があります。
### **ChartSeriesGroup.Typeプロパティの型が変更されました**
ChartSeriesGroup.Typeプロパティは、ChartType列挙型から新しいCombinableSeriesTypesGroup列挙型に変更されました。CombinableSeriesTypesGroup列挙型は、組み合わせ可能な系列タイプのグループを表します。
### **個々の形状サムネイル生成のサポートが追加されました**
Aspose.Slides.ShapeThumbnailBounds

Aspose.Slides.IShape、Aspose.Slides.Shapeの新しいメンバー:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)