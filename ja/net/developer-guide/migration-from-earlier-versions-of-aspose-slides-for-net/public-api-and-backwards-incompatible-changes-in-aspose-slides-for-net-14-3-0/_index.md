---
title: Aspose.Slides for .NET 14.3.0 のパブリック API と後方互換性のない変更
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
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

## **パブリック API および後方互換性のない変更**
### **Aspose.Slides.ShapeThumbnailBounds 列挙体と Aspose.Slides.IShape.GetThumbnail() メソッドが追加されました**
GetThumbnail() および GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) メソッドは、個別のシェイプサムネイルを作成するために使用されます。ShapeThumbnailBounds 列挙体は、利用可能なシェイプサムネイルの境界タイプを定義します。
### **プロパティ UniqueId が Aspose.Slides.IShape に追加されました**
Aspose.Slides.IShape.UniqueId プロパティは、プレゼンテーション内で一意のシェイプ識別子を取得します。この一意の識別子はシェイプのカスタムタグに保存されます。
### **IChartCategoryLevelsManager の SetGroupingItem メソッドのシグネチャが変更されました**
IChartCategoryLevelsManager メソッドのシグネチャ

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

は廃止され、以下のシグネチャに置き換えられました

``` csharp

 void SetGroupingItem(int level, object value);

``` 

したがって、次のような呼び出しは

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

以下のように変更する必要があります

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

SetGroupingItem には IChartDataCell 型の値ではなく、"Group 1" のような文字列を渡してください。カテゴリレベル用に定義されたワークシート、行、列で IChartDataCell を構築する必要がある要件は、SetGroupingItem(int, object) メソッド内にカプセル化されています。
### **SlideId プロパティが Aspose.Slides.IBaseSlide インターフェイスに追加されました**
SlideId プロパティは、一意のスライド識別子を取得します。
### **SoundName プロパティが ISlideShowTransition に追加されました**
読み書き可能な文字列。トランジションのサウンドに対する人間が読める名前を指定します。サウンド名を取得または設定するには Sound プロパティに割り当てる必要があります。この名前は、PowerPoint のユーザーインターフェイスでトランジションサウンドを手動で構成する際に表示されます。Sound プロパティが割り当てられていない場合、PptxException がスローされる可能性があります。
### **ChartSeriesGroup.Type プロパティの型が変更されました**
ChartSeriesGroup.Type プロパティは、ChartType 列挙体から新しい CombinableSeriesTypesGroup 列挙体に変更されました。CombinableSeriesTypesGroup 列挙体は、組み合わせ可能なシリーズタイプのグループを表します。
### **個別シェイプサムネイル生成のサポートが追加されました**
Aspose.Slides.ShapeThumbnailBounds

Aspose.Slides.IShape、Aspose.Slides.Shape の新メンバー:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)