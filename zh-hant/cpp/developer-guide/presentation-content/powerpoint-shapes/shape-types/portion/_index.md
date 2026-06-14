---
title: 使用 C++ 在簡報中管理文字區段
linktitle: 文字區段
type: docs
weight: 70
url: /zh-hant/cpp/portion/
keywords:
- 文字區段
- 文字片段
- 文字座標
- 文字位置
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "瞭解如何使用 Aspose.Slides for C++ 在 PowerPoint 簡報中管理文字區段，提升效能與客製化。"
---
## **簡介**

文字區段代表段落內的特定文字片段，允許您獨立於周圍內容處理該片段。 在 Aspose.Slides 中，當您需要取得文字片段的位置、僅對段落的一部分套用格式，或以更細緻的層級控制文字行為時，可使用區段。

## **取得文字區段的座標**
**GetCoordinates()** 方法已加入 IPortion 與 Portion 類別，可取得區段起始位置的座標：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```

## **常見問題**

**我可以只在單一段落的部分文字上套用超連結嗎？**

是的，您可以[指派超連結](/slides/zh-hant/cpp/manage-hyperlinks/)給單一區段；只有該片段可點擊，而不是整個段落。

**樣式繼承如何運作：Portion 會覆寫什麼，而什麼會從 Paragraph/TextFrame 繼承？**

Portion 級別的屬性具有最高優先權。若屬性未在[Portion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/portion/)上設定，則引擎會從[Paragraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/paragraph/)取得；若該處仍未設定，則會從[TextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/textframe/)或[theme](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/theme/)樣式取得。

**如果指定給 Portion 的字型在目標機器/伺服器上不存在，會發生什麼情況？**

[字型替換規則](/slides/zh-hant/cpp/font-selection-sequence/)會套用。文字可能重新換行：度量、斷字與寬度可能會改變，這對精確定位很重要。

**我可以為特定 Portion 設定文字填充透明度或漸層，且不影響段落其他部分嗎？**

是的，於[Portion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/portion/)層級的文字顏色、填充與透明度可以與相鄰片段不同。