---
title: 簡報鎖定
type: docs
weight: 110
url: /zh-hant/net/presentation-locking/
---
## **簡報鎖定**
使用 **Aspose.Slides** 的一個常見用途是於自動化工作流程中建立、更新與儲存 Microsoft PowerPoint 2007 (PPTX) 簡報。以此方式使用 Aspose.Slides 的應用程式使用者可取得輸出簡報。保護它們免於編輯是常見的需求。自動產生的簡報必須保留其原始格式與內容，這點相當重要。

本文說明簡報與投影片的建構方式，以及 Aspose.Slides for .NET 如何對簡報加上保護，並在之後移除保護。此功能是 Aspose.Slides 所特有的，撰寫本文時 Microsoft PowerPoint 尚未提供此功能。它讓開發人員得以控制其應用程式所建立的簡報的使用方式。
## **投影片的組成**
PPTX 投影片由多種元件組成，例如自動圖形、表格、OLE 物件、群組圖形、圖片框、影片框、連接線以及其他可用來建立簡報的各種元素。

在 Aspose.Slides for .NET 中，投影片上的每個元素都會轉換成 Shape 物件。換句話說，投影片上的每個元素要麼是 Shape 物件，要麼是繼承自 Shape 物件的類別。

PPTX 的結構相當複雜，與 PPT 不同，後者可以使用通用鎖定來對所有類型的圖形進行鎖定；在 PPTX 中，針對不同圖形類型有不同的鎖定類型。BaseShapeLock 類別是通用的 PPTX 鎖定類別。Aspose.Slides for .NET 在 PPTX 中支援以下類型的鎖定。

- AutoShapeLock 鎖定自動圖形。
- ConnectorLock 鎖定連接線圖形。
- GraphicalObjectLock 鎖定圖形物件。
- GroupshapeLock 鎖定群組圖形。
- PictureFrameLock 鎖定圖片框。

對 Presentation 物件中所有 Shape 物件執行的任何操作，都會套用至整個簡報。
## **套用與移除保護**
套用保護可確保簡報無法被編輯。這是一種保護簡報內容的實用技術。

**將保護套用至 PPTX Shape**

Aspose.Slides for .NET 提供 Shape 類別來處理投影片上的圖形。

如前所述，每個圖形類別都有相對應的圖形鎖定類別以實作保護。本文聚焦於 NoSelect、NoMove 與 NoResize 鎖定。這些鎖定可確保圖形無法被選取（透過滑鼠點擊或其他選取方式），且無法移動或調整大小。

以下程式碼範例會將保護套用至簡報中所有圖形類型。

``` csharp

 //實例化表示 PPTX 檔案的 Presentation 類別

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//實例化表示 PPTX 檔案的 Presentation 類別


//用於存取簡報中投影片的 ISlide 物件

SlideEx slide = pTemplate.Slides[0];

//用於保存暫時形狀的 IShape 物件

ShapeEx shape;

//遍歷簡報中的所有投影片

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//遍歷投影片中的所有圖形

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//如果圖形是自動圖形

		if (shape is AutoShapeEx)

		{

			//將類型轉換為自動圖形並取得自動圖形鎖定

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//套用圖形鎖定

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//如果圖形是群組圖形

		else if (shape is GroupShapeEx)

		{

			//將類型轉換為群組圖形並取得群組圖形鎖定

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//套用圖形鎖定

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//如果圖形是連接線

		else if (shape is ConnectorEx)

		{

			//將類型轉換為連接線圖形並取得連接線圖形鎖定

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//套用圖形鎖定

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//如果圖形是圖片框

		else if (shape is PictureFrameEx)

		{

			//將類型轉換為圖片框圖形並取得圖片框圖形鎖定

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//套用圖形鎖定

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//儲存簡報檔案

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**移除保護**

使用 Aspose.Slides for .NET 套用的保護只能以 Aspose.Slides for .NET 移除。若要解除圖形的鎖定，只需將已套用的鎖定值設為 false。以下程式碼範例示範如何在已鎖定的簡報中解除圖形的鎖定。

``` csharp

 //開啟所需的簡報
PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//ISlide 物件，用於存取簡報中的投影片
SlideEx slide = pTemplate.Slides[0];

//IShape 物件，用於保存暫時的圖形
ShapeEx shape;

//遍歷簡報中的所有投影片
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//遍歷投影片中的所有圖形
	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//如果圖形是自動圖形
		if (shape is AutoShapeEx)

		{

			//將類型轉換為自動圖形並取得自動圖形鎖定
			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//套用圖形鎖定
			AutoShapeLock.PositionLocked = false;

			AutoShapeLock.SelectLocked = false;

			AutoShapeLock.SizeLocked = false;

		}

		//如果圖形是群組圖形
		else if (shape is GroupShapeEx)

		{

			//將類型轉換為群組圖形並取得群組圖形鎖定
			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//套用圖形鎖定
			groupShapeLock.GroupingLocked = false;

			groupShapeLock.PositionLocked = false;

			groupShapeLock.SelectLocked = false;

			groupShapeLock.SizeLocked = false;

		}

		//如果圖形是連接線圖形
		else if (shape is ConnectorEx)

		{

			//將類型轉換為連接線圖形並取得連接線圖形鎖定
			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//套用圖形鎖定
			ConnLock.PositionMove = false;

			ConnLock.SelectLocked = false;

			ConnLock.SizeLocked = false;

		}

		//如果圖形是圖片框
		else if (shape is PictureFrameEx)

		{

			//將類型轉換為圖片框圖形並取得圖片框圖形鎖定
			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//套用圖形鎖定
			PicLock.PositionLocked = false;

			PicLock.SelectLocked = false;

			PicLock.SizeLocked = false;

		}

	}

}

//儲存簡報檔案
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **下載範例程式碼**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)