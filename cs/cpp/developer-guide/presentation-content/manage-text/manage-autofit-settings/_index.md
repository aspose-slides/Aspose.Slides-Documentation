---
title: Vylepšete své prezentace pomocí AutoFit v C++
linktitle: Nastavení Autofit
type: docs
weight: 30
url: /cs/cpp/manage-autofit-settings/
keywords:
- textové pole
- autofit
- neautofit
- přizpůsobit text
- zmenšit text
- zalamovat text
- změnit velikost tvaru
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Zjistěte, jak spravovat nastavení AutoFit v Aspose.Slides pro C++ a optimalizovat zobrazení textu ve vašich prezentacích PowerPoint a OpenDocument a zlepšit čitelnost obsahu."
---
## **Úvod**

Ve výchozím nastavení, když přidáte textové pole, Microsoft PowerPoint používá nastavení **Resize shape to fix text** pro textové pole — automaticky mění velikost textového pole, aby se jeho text vždy vešel.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Když se text v textovém poli prodlouží nebo zvětší, PowerPoint automaticky zvětší textové pole — zvětší jeho výšku — aby pojmul více textu. 
* Když se text v textovém poli zkrátí nebo zmenší, PowerPoint automaticky zmenší textové pole — sníží jeho výšku — a odstraní přebytečný prostor. 

V PowerPointu jsou to 4 důležité parametry nebo možnosti, které řídí chování autofit pro textové pole:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides pro C++ poskytuje podobné možnosti — některé metody ve třídě [TextFrameFormat](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.text_frame_format) — které vám umožňují řídit chování autofit pro textová pole v prezentacích. 

## **Změna velikosti tvaru tak, aby odpovídala textu**

Pokud chcete, aby text v rámečku vždy zapadal do tohoto rámečku po provedení změn textu, musíte použít možnost **Resize shape to fix text**. Pro nastavení této volby nastavte vlastnost [AutofitType](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.text_frame_format)) na `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Tento kód v C++ ukazuje, jak nastavit, aby text vždy zapadal do svého rámečku v prezentaci PowerPoint:

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

Pokud text zesílí nebo zvětší, textové pole bude automaticky změněno (zvýší se výška), aby se všechen text vešel. Pokud text zkrátí, nastane opak. 

## **Do Not Autofit**

Pokud chcete, aby textové pole nebo tvar zachovalo své rozměry bez ohledu na změny textu, musíte použít možnost **Do not Autofit**. Pro nastavení této volby nastavte vlastnost [AutofitType](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.text_frame_format)) na `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Tento kód v C++ ukazuje, jak nastavit, aby textové pole vždy zachovalo své rozměry v prezentaci PowerPoint:

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

Když se text stane příliš dlouhý pro svůj rámeček, přesahuje mimo něj. 

## **Shrink Text on Overflow**

Pokud text přesáhne velikost svého rámečku, pomocí volby **Shrink text on overflow** můžete nastavit, aby se velikost a rozestupy textu zmenšily, aby se vešly do rámečku. Pro nastavení této volby nastavte vlastnost [AutofitType](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.text_frame_format)) na `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Tento kód v C++ ukazuje, jak nastavit, aby se text při přetečení zmenšil v prezentaci PowerPoint:

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
Když je použita možnost **Shrink text on overflow**, nastavení se použije pouze tehdy, když se text stane příliš dlouhým pro svůj rámeček.
{{% /alert %}}

## **Wrap Text**

Pokud chcete, aby se text ve tvaru zalamoval uvnitř tohoto tvaru, když přesáhne jeho okraj (pouze šířka), musíte použít parametr **Wrap text in shape**. Pro nastavení této volby musíte nastavit vlastnost [WrapText](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) (třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.text_frame_format)) na `true`. 

Tento kód v C++ ukazuje, jak použít nastavení Wrap Text v prezentaci PowerPoint:

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
Pokud pro tvar nastavíte vlastnost `WrapText` na `False`, když se text uvnitř tvaru stane delší než šířka tvaru, text bude pokračovat mimo okraje tvaru v jedné řádce. 
{{% /alert %}}

## **Často kladené otázky**

**Ovlivňují vnitřní okraje textového rámce AutoFit?**

Ano. Odsazení (vnitřní okraje) snižuje použitelné místo pro text, takže AutoFit zasáhne dříve — zmenší písmo nebo dříve upraví velikost tvaru. Zkontrolujte a upravte okraje před laděním AutoFit.

**Jak AutoFit spolupracuje s ručními a měkkými zalomeními řádků?**

Vynucená zalomení zůstávají na místě a AutoFit upravuje velikost písma a rozestupy kolem nich. Odstranění zbytečných zalomení často snižuje, jak agresivně AutoFit musí text zmenšovat.

**Mění změna písma motivu nebo spuštění náhrady fontu výsledky AutoFit?**

Ano. Nahrazení fontu fontem s odlišnými metrikami glyfů mění šířku/výšku textu, což může změnit konečnou velikost písma a zalamování řádků. Po každé změně nebo náhradě fontu znovu zkontrolujte snímky.