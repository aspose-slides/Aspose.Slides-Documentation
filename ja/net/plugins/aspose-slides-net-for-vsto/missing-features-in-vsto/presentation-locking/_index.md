---
title: プレゼンテーションのロック
type: docs
weight: 110
url: /ja/net/presentation-locking/
---

## **プレゼンテーションのロック**
**Aspose.Slides** の一般的な使用例は、Microsoft PowerPoint 2007 (PPTX) プレゼンテーションを自動化ワークフローの一部として作成、更新、保存することです。このように Aspose.Slides を使用するアプリケーションのユーザーは、出力されたプレゼンテーションにアクセスできます。編集から保護することは一般的な関心事です。自動生成されたプレゼンテーションが元の書式や内容を保持することが重要です。

この文書では、プレゼンテーションとスライドがどのように構成され、Aspose.Slides for .NET がどのように保護を適用し、そしてプレゼンテーションから保護を除去できるかを説明します。この機能は Aspose.Slides に固有であり、執筆時点では Microsoft PowerPoint には存在しません。開発者は、アプリケーションが作成するプレゼンテーションの使用方法を制御する手段を得られます。

## **スライドの構成**
PPTX スライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化シェイプ、ピクチャーフレーム、ビデオフレーム、コネクタ、およびプレゼンテーションを構築するために利用できるさまざまな要素など、複数のコンポーネントで構成されています。

Aspose.Slides for .NET では、スライド上の各要素は Shape オブジェクトに変換されます。言い換えれば、スライド上の各要素は Shape オブジェクトあるいは Shape オブジェクトから派生したオブジェクトです。

PPTX の構造は複雑であるため、すべての形状タイプに対して汎用ロックを使用できる PPT とは異なり、形状タイプごとに異なるロックが用意されています。BaseShapeLock クラスは PPTX 用の汎用ロッククラスです。Aspose.Slides for .NET が PPTX でサポートするロックの種類は以下のとおりです。

- AutoShapeLock はオートシェイプをロックします。
- ConnectorLock はコネクタ形状をロックします。
- GraphicalObjectLock はグラフィカルオブジェクトをロックします。
- GroupShapeLock はグループ形状をロックします。
- PictureFrameLock はピクチャーフレームをロックします。

Presentation オブジェクト内のすべての Shape オブジェクトに対して実行される操作は、プレゼンテーション全体に適用されます。

## **保護の適用と解除**
保護を適用すると、プレゼンテーションを編集できなくなります。これはプレゼンテーションの内容を保護する有用な手法です。

**PPTX シェイプへの保護の適用**

Aspose.Slides for .NET は、スライド上のシェイプを操作するための Shape クラスを提供します。

前述のとおり、各シェイプ クラスには保護用のシェイプ ロック クラスが関連付けられています。本稿では NoSelect、NoMove、NoResize ロックに焦点を当てます。これらのロックにより、シェイプを選択（マウスクリックやその他の選択方法）できず、移動やサイズ変更もできなくなります。

以下のコードサンプルは、プレゼンテーション内のすべてのシェイプタイプに保護を適用します。

``` csharp

 //Instatiate Presentation class that represents a PPTX file

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//Instatiate Presentation class that represents a PPTX file


//ISlide object for accessing the slides in the presentation

SlideEx slide = pTemplate.Slides[0];

//IShape object for holding temporary shapes

ShapeEx shape;

//Traversing through all the slides in the presentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Travesing through all the shapes in the slides

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//if shape is autoshape

		if (shape is AutoShapeEx)

		{

			//Type casting to Auto shape and  getting auto shape lock

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Applying shapes locks

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//if shape is group shape

		else if (shape is GroupShapeEx)

		{

			//Type casting to group shape and  getting group shape lock

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Applying shapes locks

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//if shape is a connector

		else if (shape is ConnectorEx)

		{

			//Type casting to connector shape and  getting connector shape lock

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Applying shapes locks

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//if shape is picture frame

		else if (shape is PictureFrameEx)

		{

			//Type casting to picture frame shape and  getting picture frame shape lock

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Applying shapes locks

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//Saving the presentation file

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**保護の解除**

Aspose.Slides for .NET で適用した保護は、Aspose.Slides for .NET でのみ解除できます。シェイプのロックを解除するには、適用されたロックの値を false に設定します。以下のコードサンプルは、ロックされたプレゼンテーション内のシェイプを解除する方法を示しています。

``` csharp

 //Open the desired presentation

PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//ISlide object for accessing the slides in the presentation

SlideEx slide = pTemplate.Slides[0];

//IShape object for holding temporary shapes

ShapeEx shape;

//Traversing through all the slides in presentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Travesing through all the shapes in the slides

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//if shape is autoshape

		if (shape is AutoShapeEx)

		{

			//Type casting to Auto shape and  getting auto shape lock

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Applying shapes locks

			AutoShapeLock.PositionLocked = false;

			AutoShapeLock.SelectLocked = false;

			AutoShapeLock.SizeLocked = false;

		}

		//if shape is group shape

		else if (shape is GroupShapeEx)

		{

			//Type casting to group shape and  getting group shape lock

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Applying shapes locks

			groupShapeLock.GroupingLocked = false;

			groupShapeLock.PositionLocked = false;

			groupShapeLock.SelectLocked = false;

			groupShapeLock.SizeLocked = false;

		}

		//if shape is Connector shape

		else if (shape is ConnectorEx)

		{

			//Type casting to connector shape and  getting connector shape lock

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Applying shapes locks

			ConnLock.PositionMove = false;

			ConnLock.SelectLocked = false;

			ConnLock.SizeLocked = false;

		}

		//if shape is picture frame

		else if (shape is PictureFrameEx)

		{

			//Type casting to pitcture frame shape and  getting picture frame shape lock

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Applying shapes locks

			PicLock.PositionLocked = false;

			PicLock.SelectLocked = false;

			PicLock.SizeLocked = false;

		}

	}

}

//Saving the presentation file

pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **サンプルコードのダウンロード**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812535)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)