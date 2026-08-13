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
description: "Zjistěte, jak přidat záhlaví a zápatí do prezentací PowerPoint PPT, PPTX a ODP v .NET pomocí starých i moderních API Aspose.Slides."
---
{{% alert color="info" %}}

Nové [Aspose.Slides for .NET API](/slides/cs/net/) bylo vydáno a nyní tento jediný produkt podporuje možnost generovat PowerPoint dokumenty od začátku i upravovat existující.

{{% /alert %}} 
## **Podpora pro legacy kód**
Aby bylo možné použít legacy kód vyvinutý pro Aspose.Slides pro .NET verze starší než 13.x, musíte provést několik drobných změn ve svém kódu a kód bude fungovat jako dříve. Všechny třídy, které byly v starém Aspose.Slides pro .NET v rámci jmenných prostorů Aspose.Slide a Aspose.Slides.Pptx, jsou nyní sloučeny do jediného jmenného prostoru Aspose.Slides. Podívejte se na následující jednoduchý úryvek kódu pro přidání záhlaví a zápatí v prezentaci ve starém Aspose.Slides API a postupujte podle kroků popisujících, jak migrovat na nové sloučené API.
## **Zastaralý přístup k Aspose.Slides pro .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Nastavení viditelnosti záhlaví a zápatí
//Aktualizovat pole data a času
//Zobrazit zástupný znak data a času
//Zobrazit zástupný znak zápatí
//Zobrazit číslo snímku
//Nastavit viditelnost záhlaví a zápatí na titulním snímku
//Zapsat prezentaci na disk
sourcePres.Write("NewSource.pptx");
```

```c#
using Aspose.Slides;

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



## **Nový přístup k Aspose.Slides pro .NET 13.x**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation sourcePres = new Presentation())
{
    //Nastavení viditelnosti záhlaví a zápatí
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Aktualizovat pole data a času
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Zobrazit zástupný znak data a času
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Zobrazit zástupný znak zápatí
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Nastavit  viditelnost záhlaví a zápatí na titulním snímku
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Zapsat prezentaci na disk
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```