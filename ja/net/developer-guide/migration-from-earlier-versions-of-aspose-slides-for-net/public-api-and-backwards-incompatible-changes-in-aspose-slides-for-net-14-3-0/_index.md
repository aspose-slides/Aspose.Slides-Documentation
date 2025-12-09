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
- 従来のアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のパブリック API 更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

## **パブリック API と下位互換性のない変更**
### **Aspose.Slides.ShapeThumbnailBounds 列挙体 と Aspose.Slides.IShape.GetThumbnail() メソッドが追加**
GetThumbnail() メソッドおよび GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) メソッドは、個別のシェイプサムネイルを作成するために使用されます。ShapeThumbnailBounds 列挙体は、可能なシェイプサムネイルの境界タイプを定義します。
### **Aspose.Slides.IShape に UniqueId プロパティが追加**
Aspose.Slides.IShape.UniqueId プロパティは、プレゼンテーション スコープ内で一意のシェイプ識別子を取得します。これらの一意の識別子はシェイプのカスタムタグに保存されます。
### **IChartCategoryLevelsManager の SetGroupingItem メソッドのシグネチャが変更**
IChartCategoryLevelsManager の SetGroupingItem メソッドのシグネチャが変更されました

``` csharp
 void SetGroupingItem(int level, IChartDataCell value);
``` 

は現在廃止され、次のシグネチャに置き換えられました

``` csharp
 void SetGroupingItem(int level, object value);
``` 

今後は次のように呼び出す必要があります

``` csharp
 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));
``` 

次のように変更してください

``` csharp
 .SetGroupingItem(1, "Group 1");
``` 

"Group 1" のような文字列を SetGroupingItem に渡し、IChartDataCell 型の値は渡さないでください。カテゴリーレベル用に定義されたワークシート、行、列で IChartDataCell を構成する必要がある要件があり、これらは SetGroupingItem(int, object) メソッドにカプセル化されました。
### **Aspose.Slides.IBaseSlide インターフェイスに SlideId プロパティが追加**
SlideId プロパティは、一意のスライド識別子を取得します。
### **ISlideShowTransition に SoundName プロパティが追加**
読み書き可能な文字列です。トランジションのサウンドの人間が読める名前を指定します。Sound プロパティに割り当てることでサウンド名の取得または設定が可能です。この名前は、トランジションサウンドを手動で設定する際に PowerPoint のユーザーインターフェイスに表示されます。Sound プロパティが割り当てられていない場合、PptxException がスローされる可能性があります。
### **ChartSeriesGroup.Type プロパティの型が変更**
ChartSeriesGroup.Type プロパティは、ChartType 列挙体から新しい CombinableSeriesTypesGroup 列挙体に変更されました。CombinableSeriesTypesGroup 列挙体は、組み合わせ可能な系列タイプのグループを表します。
### **個別シェイプサムネイル生成のサポートが追加**
Aspose.Slides.ShapeThumbnailBounds

Aspose.Slides.IShape、Aspose.Slides.Shape の新しいメンバー:
``` csharp
 public Bitmap GetThumbnail()
```
``` csharp
 public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)
```