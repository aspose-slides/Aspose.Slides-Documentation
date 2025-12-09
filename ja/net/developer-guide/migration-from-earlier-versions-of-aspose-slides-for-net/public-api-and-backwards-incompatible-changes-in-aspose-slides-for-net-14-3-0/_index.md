---
title: Aspose.Slides for .NET 14.3.0 のパブリック API と後方互換性のない変更
linktitle: Aspose.Slides for .NET 14.3.0
type: docs
weight: 50
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- マイグレーション
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
description: "Aspose.Slides for .NET のパブリック API 更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

## **パブリック API と後方互換性のない変更**
### **Aspose.Slides.ShapeThumbnailBounds 列挙体と Aspose.Slides.IShape.GetThumbnail() メソッドが追加されました**
GetThumbnail() メソッドと GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) メソッドは、個別のシェイプサムネイルを作成するために使用されます。ShapeThumbnailBounds 列挙体は、可能なシェイプサムネイルの境界タイプを定義します。
### **Aspose.Slides.IShape に UniqueId プロパティが追加されました**
Aspose.Slides.IShape.UniqueId プロパティは、プレゼンテーション内で一意のシェイプ識別子を取得します。これらの一意の識別子はシェイプのカスタムタグに保存されます。
### **IChartCategoryLevelsManager の SetGroupingItem メソッドのシグネチャが変更されました**
IChartCategoryLevelsManager メソッドのシグネチャ

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

は廃止され、次のシグネチャに置き換えられました

``` csharp

 void SetGroupingItem(int level, object value);

``` 

例えば次の呼び出しは

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

次のように変更する必要があります

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

SetGroupingItem には IChartDataCell 型ではなく "Group 1" のような文字列を渡してください。カテゴリレベル用に定義されたワークシート、行、列で IChartDataCell を構築するにはいくつかの要件があり、SetGroupingItem(int, object) メソッドにカプセル化されています。
### **Aspose.Slides.IBaseSlide インターフェイスに SlideId プロパティが追加されました**
SlideId プロパティは、一意のスライド識別子を取得します。
### **ISlideShowTransition に SoundName プロパティが追加されました**
読み書き可能な文字列です。トランジションのサウンドに対する人間が読みやすい名前を指定します。サウンド名を取得または設定するには Sound プロパティを設定する必要があります。この名前は、トランジションサウンドを手動で設定する際に PowerPoint のユーザーインターフェイスに表示されます。Sound プロパティが設定されていない場合、PptxException がスローされることがあります。
### **ChartSeriesGroup.Type プロパティの型が変更されました**
ChartSeriesGroup.Type プロパティは ChartType 列挙体から新しい CombinableSeriesTypesGroup 列挙体に変更されました。CombinableSeriesTypesGroup 列挙体は、組み合わせ可能な系列タイプのグループを表します。
### **個別シェイプサムネイル生成のサポートが追加されました**
Aspose.Slides.ShapeThumbnailBounds

Aspose.Slides.IShape、Aspose.Slides.Shape の新しいメンバー:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)