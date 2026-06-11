---
title: Förbättra dina presentationer med AutoFit i C++
linktitle: Autofit-inställningar
type: docs
weight: 30
url: /sv/cpp/manage-autofit-settings/
keywords:
- textruta
- autofit
- ingen autofit
- anpassa text
- krymp text
- radbryt text
- ändra storlek på form
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du hanterar AutoFit-inställningar i Aspose.Slides för C++ för att optimera textvisning i dina PowerPoint- och OpenDocument-presentationer och förbättra läsbarheten av innehållet."
---
## **Introduktion**

Som standard, när du lägger till en textruta, använder Microsoft PowerPoint inställningen **Resize shape to fix text** för textrutan—den anpassar automatiskt textrutan så att dess text alltid får plats i den. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* När texten i textrutan blir längre eller större, förstorar PowerPoint automatiskt textrutan—ökar dess höjd—för att låta den rymma mer text. 
* När texten i textrutan blir kortare eller mindre, minskar PowerPoint automatiskt textrutan—minskar dess höjd—för att ta bort överflödig plats. 

I PowerPoint är detta de 4 viktiga parametrarna eller alternativen som styr autofit‑beteendet för en textruta: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides för C++ tillhandahåller liknande alternativ—några metoder under klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.text_frame_format)—som låter dig kontrollera autofit‑beteendet för textrutor i presentationer. 

## **Ändra storlek på en form för att passa text**

Om du vill att texten i en ruta alltid ska få plats i den efter att texten ändrats, måste du använda alternativet **Resize shape to fix text**. För att ange den här inställningen, sätt egenskapen [AutofitType](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.text_frame_format)) till `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Denna C++‑kod visar hur du anger att en text alltid ska få plats i sin ruta i en PowerPoint‑presentation:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Shape);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

Om texten blir längre eller större, kommer textrutan automatiskt att anpassas (höjden ökas) så att all text får plats. Om texten blir kortare sker motsatsen. 

## **Do Not Autofit**

Om du vill att en textruta eller form ska behålla sina dimensioner oavsett vilka ändringar som görs i den text den innehåller, måste du använda alternativet **Do not Autofit**. För att ange den här inställningen, sätt egenskapen [AutofitType](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.text_frame_format)) till `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Denna C++‑kod visar hur du anger att en textruta alltid ska behålla sina dimensioner i en PowerPoint‑presentation:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::None);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

När texten blir för lång för sin ruta läcker den ut. 

## **Shrink Text on Overflow**

Om en text blir för lång för sin ruta kan du, genom alternativet **Shrink text on overflow**, ange att textens storlek och avstånd ska minskas så att den får plats i rutan. För att ange den här inställningen, sätt egenskapen [AutofitType](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.text_frame_format)) till `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Denna C++‑kod visar hur du anger att en text ska krympas vid överspill i en PowerPoint‑presentation:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Normal);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Info" color="info" %}}
När alternativet **Shrink text on overflow** används tillämpas inställningen endast när texten blir för lång för sin ruta. 
{{% /alert %}}

## **Wrap Text**

Om du vill att texten i en form ska radbrytas inom den när texten går utanför formens kant (endast bredd), måste du använda parametern **Wrap text in shape**. För att ange den här inställningen, sätt egenskapen [WrapText](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.text_frame_format)) till `true`. 

Denna C++‑kod visar hur du använder inställningen Wrap Text i en PowerPoint‑presentation:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_WrapText(NullableBool::True);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Om du sätter egenskapen `WrapText` till `False` för en form, när texten i formen blir längre än formens bredd, sträcker sig texten utanför formens kanter på en enda rad. 
{{% /alert %}}

## **Vanliga frågor**

**Påverkar textramens interna marginaler AutoFit?**  
Ja. Padding (inre marginaler) minskar det användbara området för text, så AutoFit triggas tidigare—fonten krymper eller formen anpassas tidigare. Kontrollera och justera marginalerna innan du finjusterar AutoFit.

**Hur interagerar AutoFit med manuella och mjuka radbrytningar?**  
Tvingade radbrytningar förblir, och AutoFit anpassar fontstorlek och avstånd runt dem. Att ta bort onödiga brytningar minskar ofta hur aggressivt AutoFit måste krympa texten.

**Påverkar ändring av temafont eller aktivering av fontersättning AutoFit‑resultaten?**  
Ja. Att ersätta med en font som har andra glyf‑mått förändrar textens bredd/höjd, vilket kan ändra slutlig fontstorlek och radbrytning. Efter någon fontändring eller ersättning, kontrollera presentationerna igen.