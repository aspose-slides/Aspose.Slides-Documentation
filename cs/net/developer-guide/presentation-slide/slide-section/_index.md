---
title: Správa sekcí snímků v prezentacích v .NET
linktitle: Sekce snímků
type: docs
weight: 100
url: /cs/net/slide-section/
keywords:
- vytvořit sekci
- přidat sekci
- upravit sekci
- změnit sekci
- název sekce
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zefektivněte sekce snímků v PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET — rozdělte, přejmenujte a přeuspořádejte pro optimalizaci pracovních toků PPTX a ODP."
---
## **Úvod**

S Aspose.Slides pro .NET můžete organizovat prezentaci PowerPoint do sekcí. Můžete vytvářet sekce, které obsahují konkrétní snímky. 

Můžete chtít vytvořit sekce a použít je k uspořádání nebo rozdělení snímků v prezentaci na logické části v následujících situacích:

- Když pracujete na velké prezentaci s dalšími lidmi nebo týmem — a potřebujete přiřadit určité snímky kolegovi nebo několika členům týmu. 
- Když máte prezentaci obsahující mnoho snímků — a obtížně zvládáte spravovat nebo upravovat její obsah najednou.

Ideálně byste měli vytvořit sekci, která obsahuje podobné snímky — snímky mají něco společného nebo mohou být seskupeny podle pravidla — a dát sekci název, který popisuje snímky uvnitř ní. 

## **Vytváření sekcí v prezentacích**

Pro přidání sekce, která bude obsahovat snímky v prezentaci, poskytuje Aspose.Slides pro .NET metodu AddSection, která vám umožňuje specifikovat název sekce, kterou chcete vytvořit, a snímek, od kterého sekce začíná. 

Tento ukázkový kód ukazuje, jak vytvořit sekci v prezentaci v C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1 bude ukončena na newSlide2 a po ní začne section2   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## **Změna názvů sekcí**

Po vytvoření sekce v prezentaci PowerPoint můžete rozhodnout o změně jejího názvu. 

Tento ukázkový kód ukazuje, jak změnit název sekce v prezentaci v C# pomocí Aspose.Slides:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```

## **Často kladené otázky**

**Zůstávají sekce zachovány při ukládání do formátu PPT (PowerPoint 97–2003)?**

Ne. Formát PPT nepodporuje metadata sekcí, takže seskupení sekcí se při ukládání do .ppt ztratí.

**Lze skrýt celou sekci?**

Ne. Lze skrýt pouze jednotlivé snímky. Sekce jako entita nemá stav „skrytý“.

**Mohu rychle najít sekci podle snímku a naopak první snímek sekce?**

Ano. Sekce je jednoznačně definována svým úvodním snímkem; pokud znáte snímek, můžete určit, do které sekce patří, a pro sekci můžete získat její první snímek.