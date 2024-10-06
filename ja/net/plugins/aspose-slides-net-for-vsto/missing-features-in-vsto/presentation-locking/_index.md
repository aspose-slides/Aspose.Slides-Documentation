---
title: プレゼンテーションのロック
type: docs
weight: 110
url: /ja/net/presentation-locking/
---

## **プレゼンテーションのロック**
**Aspose.Slides**の一般的な使用法は、Microsoft PowerPoint 2007 (PPTX) プレゼンテーションを自動化されたワークフローの一部として作成、更新、保存することです。このようにAspose.Slidesを使用するアプリケーションのユーザーは、出力されたプレゼンテーションにアクセスできます。それを編集から保護することは一般的な懸念です。自動生成されたプレゼンテーションが元のフォーマットと内容を保持することが重要です。

これは、プレゼンテーションとスライドがどのように構築され、Aspose.Slides for .NETがプレゼンテーションに保護を適用し、その後それを削除できるかを説明します。この機能はAspose.Slidesに特有であり、執筆時点でMicrosoft PowerPointでは利用できません。これは、開発者がアプリケーションが作成するプレゼンテーションの使用方法を制御する手段を提供します。
## **スライドの構成**
PPTXスライドは、オートシェイプ、テーブル、OLEオブジェクト、グループ化されたシェイプ、ピクチャーフレーム、ビデオフレーム、コネクタおよびプレゼンテーションを構成するために使用できるその他のさまざまな要素など、いくつかのコンポーネントで構成されています。

Aspose.Slides for .NETでは、スライド上の各要素がShapeオブジェクトに変換されます。つまり、スライド上の各要素はShapeオブジェクトまたはShapeオブジェクトから派生したオブジェクトです。

PPTXの構造は複雑であるため、すべてのシェイプタイプに対して一般的なロックを使用できるPPTとは異なり、異なるシェイプタイプに対して異なる種類のロックがあります。BaseShapeLockクラスは一般的なPPTXロッキングクラスです。Aspose.Slides for .NETでPPTXのためにサポートされているロックの種類は以下の通りです。

- AutoShapeLockはオートシェイプをロックします。
- ConnectorLockはコネクタシェイプをロックします。
- GraphicalObjectLockはグラフィカルオブジェクトをロックします。
- GroupshapeLockはグループシェイプをロックします。
- PictureFrameLockはピクチャーフレームをロックします。

プレゼンテーションオブジェクト内のすべてのShapeオブジェクトに対して実行されるアクションは、プレゼンテーション全体に適用されます。
## **保護の適用と削除**
保護を適用すると、プレゼンテーションが編集できなくなります。これは、プレゼンテーションの内容を保護するための有用な手法です。

**PPTX Shapesへの保護の適用**

Aspose.Slides for .NETは、スライド上のシェイプを扱うためにShapeクラスを提供します。

前述のように、各シェイプクラスには保護用の関連するシェイプロッククラスがあります。この記事では、NoSelect、NoMove、NoResizeロックに焦点を当てています。これらのロックは、シェイプが選択できない（マウスクリックやその他の選択方法を通じて）こと、移動もリサイズもできないことを保証します。

以下のコードサンプルは、プレゼンテーション内のすべてのシェイプタイプに保護を適用します。

``` csharp

 //PPTXファイルを表すPresentationクラスをインスタンス化する

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//PPTXファイルを表すPresentationクラスをインスタンス化する


//プレゼンテーション内のスライドにアクセスするためのISlideオブジェクト

SlideEx slide = pTemplate.Slides[0];

//一時的なシェイプを保持するためのIShapeオブジェクト

ShapeEx shape;

//プレゼンテーション内のすべてのスライドを走査する

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//スライド内のすべてのシェイプを走査する

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//シェイプがオートシェイプの場合

		if (shape is AutoShapeEx)

		{

			//オートシェイプにキャストしてオートシェイプロックを取得する

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//シェイプロックを適用する

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//シェイプがグループシェイプの場合

		else if (shape is GroupShapeEx)

		{

			//グループシェイプにキャストしてグループシェイプロックを取得する

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//シェイプロックを適用する

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//シェイプがコネクタの場合

		else if (shape is ConnectorEx)

		{

			//コネクタシェイプにキャストしてコネクタシェイプロックを取得する

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//シェイプロックを適用する

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//シェイプがピクチャーフレームの場合

		else if (shape is PictureFrameEx)

		{

			//ピクチャーフレームシェイプにキャストしてピクチャーフレームシェイプロックを取得する

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//シェイプロックを適用する

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//プレゼンテーションファイルを保存する

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**保護の削除**

Aspose.Slides for .NETを使用して適用された保護は、Aspose.Slides for .NETでのみ削除できます。シェイプをロック解除するには、適用されたロックの値をfalseに設定します。以下のコードサンプルは、ロックされたプレゼンテーション内のシェイプをロック解除する方法を示しています。

``` csharp

 //目的のプレゼンテーションを開く

PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");
 
//プレゼンテーション内のスライドにアクセスするためのISlideオブジェクト

SlideEx slide = pTemplate.Slides[0];

//一時的なシェイプを保持するためのIShapeオブジェクト

ShapeEx shape;

//プレゼンテーション内のすべてのスライドを走査する

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//スライド内のすべてのシェイプを走査する

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//シェイプがオートシェイプの場合

		if (shape is AutoShapeEx)

		{

			//オートシェイプにキャストしてオートシェイプロックを取得する

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//シェイプロックを適用する

			AutoShapeLock.PositionLocked = false;

			AutoShapeLock.SelectLocked = false;

			AutoShapeLock.SizeLocked = false;

		}

		//シェイプがグループシェイプの場合

		else if (shape is GroupShapeEx)

		{

			//グループシェイプにキャストしてグループシェイプロックを取得する

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//シェイプロックを適用する

			groupShapeLock.GroupingLocked = false;

			groupShapeLock.PositionLocked = false;

			groupShapeLock.SelectLocked = false;

			groupShapeLock.SizeLocked = false;

		}

		//シェイプがコネクタの場合

		else if (shape is ConnectorEx)

		{

			//コネクタシェイプにキャストしてコネクタシェイプロックを取得する

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//シェイプロックを適用する

			ConnLock.PositionMove = false;

			ConnLock.SelectLocked = false;

			ConnLock.SizeLocked = false;

		}

		//シェイプがピクチャーフレームの場合

		else if (shape is PictureFrameEx)

		{

			//ピクチャーフレームシェイプにキャストしてピクチャーフレームシェイプロックを取得する

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//シェイプロックを適用する

			PicLock.PositionLocked = false;

			PicLock.SelectLocked = false;

			PicLock.SizeLocked = false;

		}

	}

}

//プレゼンテーションファイルを保存する

pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **サンプルコードのダウンロード**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812535)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)