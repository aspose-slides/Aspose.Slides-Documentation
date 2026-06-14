---
title: 使用形狀鎖定防止簡報編輯
linktitle: 防止簡報編輯
type: docs
weight: 10
url: /zh-hant/cpp/applying-protection-to-presentation/
keywords:
- 防止編輯
- 保護免於編輯
- 鎖定形狀
- 鎖定位置
- 鎖定選取
- 鎖定大小
- 鎖定群組
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 如何在 PPT、PPTX 與 ODP 檔案中鎖定或解除鎖定形狀，保護簡報安全，同時允許受控的編輯並加速交付。"
---
## **背景**

Aspose.Slides 的常見用途是於自動化工作流程中建立、更新並儲存 Microsoft PowerPoint (PPTX) 試算表。以此方式使用 Aspose.Slides 的應用程式使用者會取得產生的簡報，因此防止簡報被編輯是一項常見需求。自動產生的簡報必須保留其原始格式與內容，這點非常重要。

本文說明簡報與投影片的結構，以及 Aspose.Slides for C++ 如何對簡報套用保護並稍後移除保護。它為開發人員提供了一種方式，讓應用程式產生的簡報使用方式可受控。

## **投影片的組成**

簡報投影片由自動圖形、表格、OLE 物件、群組圖形、圖片框、影片框、連接線以及其他用於建構簡報的元素組成。在 Aspose.Slides for C++ 中，投影片上的每個元素皆以實作了[IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/)介面或繼承自其子類別的物件表示。

PPTX 的結構相當複雜，與 PPT 不同，PPTX 不能使用單一通用的鎖定方式套用於所有圖形類型，不同圖形類型需要不同的鎖定。[IBaseShapeLock](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseshapelock/) 介面是 PPTX 的通用鎖定類別。Aspose.Slides for C++ 在 PPTX 中支援以下類型的鎖定：

- [IAutoShapeLock](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshapelock/) 鎖定自動圖形。  
- [IConnectorLock](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iconnectorlock/) 鎖定連接線圖形。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/igraphicalobjectlock/) 鎖定圖形物件。  
- [IGroupShapeLock](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/igroupshapelock/) 鎖定群組圖形。  
- [IPictureFrameLock](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframelock/) 鎖定圖片框。   

對 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 物件中所有圖形物件執行的任何操作，都會套用到整個簡報。

## **套用與移除保護**

套用保護可確保簡報無法被編輯。這是一項用於保護簡報內容的實用技巧。

### **將保護套用於 PPTX 圖形**

Aspose.Slides for C++ 提供了[IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/)介面，以操作投影片上的圖形。

如前所述，每個圖形類別都有對應的圖形鎖定類別用於保護。本文聚焦於 NoSelect、NoMove 與 NoResize 鎖定。這些鎖定可防止圖形被選取（透過滑鼠點擊或其他選取方式），以及防止圖形被移動或調整大小。

以下程式碼範例會將保護套用至簡報中所有圖形類型。

```cpp
// 實例化代表 PPTX 檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// 遍歷簡報中的所有投影片。
for (auto&& slide : presentation->get_Slides())	{

	// 遍歷投影片中的所有圖形。
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// 把圖形型別轉換為自動圖形並取得其形狀鎖定。
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// 把圖形型別轉換為群組圖形並取得其形狀鎖定。
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// 把圖形型別轉換為連接線圖形並取得其形狀鎖定。
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// 把圖形型別轉換為圖片框並取得其形狀鎖定。
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// 儲存簡報檔案。
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **移除保護**

若要解除圖形的鎖定，只需將已套用的鎖定值設為`false`。下列程式碼範例示範如何在已鎖定的簡報中解除圖形的鎖定。

```cpp
// 實例化代表 PPTX 檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// 遍歷簡報中的所有投影片。
for (auto&& slide : presentation->get_Slides())	{

	// 遍歷投影片中的所有圖形。
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// 將圖形類型轉換為自動圖形並取得其形狀鎖定。
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// 將圖形類型轉換為群組圖形並取得其形狀鎖定。
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// 將圖形類型轉換為連接線圖形並取得其形狀鎖定。
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// 將圖形類型轉換為圖片框並取得其形狀鎖定。
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// 儲存簡報檔案。
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **結論**

Aspose.Slides 提供多種方式來保護簡報中的圖形。您可以鎖定單一圖形，或遍歷簡報中的所有圖形並逐一鎖定，以有效保護整個檔案。亦可透過將鎖定值設為`false` 來移除保護。

## **常見問答**

**我可以在同一個簡報中同時使用圖形鎖定與密碼保護嗎？**

可以。鎖定限制檔案內物件的編輯，而[密碼保護](/slides/zh-hant/cpp/password-protected-presentation/)則控制開啟與/或儲存變更的存取權限。這兩種機制彼此補足，協同運作。

**我可以限制特定投影片的編輯而不影響其他投影片嗎？**

可以。只對選定投影片上的圖形套用鎖定，其餘投影片仍保持可編輯。

**圖形鎖定是否適用於群組物件與連接線？**

是的。針對群組、連接線、圖形物件以及其他圖形類型皆支援專屬的鎖定類型。