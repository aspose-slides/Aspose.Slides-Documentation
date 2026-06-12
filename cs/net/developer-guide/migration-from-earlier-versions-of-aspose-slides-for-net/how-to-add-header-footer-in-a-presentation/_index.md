---
title: Jak přidat záhlaví a zápatí do prezentací v .NET
linktitle: Přidat záhlaví a zápatí
type: docs
weight: 20
url: /cs/net/how-to-add-header-footer-in-a-presentation/
keywords:
- migrace
- přidat záhlaví
- přidat zápatí
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak přidat záhlaví a zápatí v prezentacích PowerPoint PPT, PPTX a ODP v .NET pomocí jak starého, tak moderního rozhraní Aspose.Slides API."
---
{{% alert color="primary" %}} 

Bylo vydáno nové rozhraní [Aspose.Slides for .NET API](/slides/cs/net/) a nyní tento jediný produkt podporuje možnost vytvářet PowerPoint dokumenty od nuly a upravovat stávající.

{{% /alert %}} 
## **Podpora pro starý kód**
Aby bylo možné použít legacy kód vyvinutý s Aspose.Slides pro .NET ve verzích starších než 13.x, je třeba provést několik drobných úprav ve vašem kódu a kód bude fungovat jako dříve. Všechny třídy, které byly v staré verzi Aspose.Slides pro .NET v namespacech Aspose.Slide a Aspose.Slides.Pptx, jsou nyní sloučeny do jediného namespace Aspose.Slides. Podívejte se na následující jednoduchý útržek kódu pro přidání záhlaví a zápatí do prezentace v legacy API Aspose.Slides a postupujte podle kroků popisujících, jak migrovat na nové sloučené API.

## **Legacy Aspose.Slides pro .NET přístup**
```c#
PresentationEx sourcePres = new PresentationEx();

//Nastavení viditelnosti záhlaví a zápatí
sourcePres.UpdateSlideNumberFields = true;

//Aktualizovat pole data a času
sourcePres.UpdateDateTimeFields = true;

//Zobrazit zástupný symbol data a času
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Zobrazit zástupný symbol zápatí
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Zobrazit číslo snímku
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Nastavit viditelnost záhlaví a zápatí na titulním snímku
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Zapsat prezentaci na disk
sourcePres.Write("NewSource.pptx");
```

```c#
//Vytvořit prezentaci
Presentation pres = new Presentation();

//Získat první snímek
Slide sld = pres.GetSlideByPosition(1);

//Přístup k záhlaví / zápatí snímku
HeaderFooter hf = sld.HeaderFooter;

//Nastavit viditelnost čísla stránky
hf.PageNumberVisible = true;

//Nastavit viditelnost zápatí
hf.FooterVisible = true;

//Nastavit viditelnost záhlaví
hf.HeaderVisible = true;

//Nastavit viditelnost data a času
hf.DateTimeVisible = true;

//Nastavit formát data a času
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Nastavit text záhlaví
hf.HeaderText = "Header Text";

//Nastavit text zápatí
hf.FooterText = "Footer Text";

//Zapsat prezentaci na disk
pres.Write("HeadFoot.ppt");
```

## **Nový Aspose.Slides pro .NET 13.x přístup**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Nastavení viditelnosti záhlaví a zápatí
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Aktualizovat pole data a času
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Zobrazit zástupný symbol data a času
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Zobrazit zástupný symbol zápatí
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Nastavit viditelnost záhlaví a zápatí na titulním snímku
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Zapsat prezentaci na disk
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```