---
title: Aspose.Slides for .NET 14.3.0 のパブリック API と下位互換性のない変更
linktitle: Aspose.Slides for .NET 14.3.0
type: docs
weight: 50
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

## **公開 API と下位互換性のない変更**
### **Aspose.Slides.ShapeThumbnailBounds 列挙体 と Aspose.Slides.IShape.GetThumbnail() メソッドが追加されました**
GetThumbnail() および GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) メソッドは、個別のシェイプサムネイルを作成するために使用されます。ShapeThumbnailBounds 列挙体は、可能なシェイプサムネイルの境界タイプを定義します。
### **Aspose.Slides.IShape に UniqueId プロパティが追加されました**
Aspose.Slides.IShape.UniqueId プロパティは、プレゼンテーション内でユニークなシェイプ識別子を取得します。これらのユニーク識別子はシェイプのカスタムタグに保存されます。
### **IChartCategoryLevelsManager の SetGroupingItem メソッドのシグネチャが変更されました**
IChartCategoryLevelsManager メソッドのシグネチャ

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

は廃止され、次のシグネチャに置き換えられました

``` csharp

 void SetGroupingItem(int level, object value);

``` 

現在の呼び出し例

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

は次のように変更する必要があります

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

"Group 1" のような文字列を SetGroupingItem に渡し、IChartDataCell 型の値は渡さないでください。カテゴリレベル用に定義されたワークシート、行、列で IChartDataCell を構築する必要がある要件は、SetGroupingItem(int, object) メソッドにカプセル化されています。
### **Aspose.Slides.IBaseSlide インターフェイスに SlideId プロパティが追加されました**
SlideId プロパティはユニークなスライド識別子を取得します。
### **ISlideShowTransition に SoundName プロパティが追加されました**
読み書き可能な文字列。トランジションサウンドの人間が読める名前を指定します。Sound プロパティに割り当てられている必要があり、サウンド名の取得または設定に使用されます。この名前は、PowerPoint のユーザーインターフェイスでトランジションサウンドを手動で設定するときに表示されます。Sound プロパティが割り当てられていない場合、PptxException がスローされる可能性があります。
### **ChartSeriesGroup.Type プロパティの型が変更されました**
ChartSeriesGroup.Type プロパティは ChartType 列挙体から新しい CombinableSeriesTypesGroup 列挙体に変更されました。CombinableSeriesTypesGroup 列挙体は、組み合わせ可能な系列タイプのグループを表します。
### **個別シェイプサムネイル生成のサポートが追加されました**
Aspose.Slides.ShapeThumbnailBounds

Aspose.Slides.IShape、Aspose.Slides.Shape の新しいメンバー:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)