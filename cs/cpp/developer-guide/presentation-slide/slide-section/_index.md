---
title: Správa sekcí snímků v prezentacích pomocí C++
linktitle: Sekce snímku
type: docs
weight: 100
url: /cs/cpp/slide-section/
keywords:
- vytvořit sekci
- přidat sekci
- upravit sekci
- změnit sekci
- název sekce
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Zefektivněte sekce snímků v PowerPointu a OpenDocument pomocí Aspose.Slides pro C++ — rozdělte, přejmenujte a přeuspořádejte je pro optimalizaci pracovních toků PPTX a ODP."
---
## **Úvod**

S Aspose.Slides for C++ můžete organizovat prezentaci PowerPoint do sekcí. Můžete vytvářet sekce, které obsahují konkrétní snímky. 

Můžete chtít vytvořit sekce a použít je k organizaci nebo rozdělení snímků v prezentaci na logické části v těchto situacích:

- Když pracujete na velké prezentaci s dalšími lidmi nebo týmem — a potřebujete přiřadit určité snímky kolegovi nebo některým členům týmu. 
- Když se potýkáte s prezentací obsahující mnoho snímků — a máte potíže s jejich správou nebo úpravou najednou.

Ideálně byste měli vytvořit sekci, která obsahuje podobné snímky — snímky mají něco společného nebo mohou existovat ve skupině podle pravidla — a dát sekci název, který popisuje snímky uvnitř ní. 

## **Vytvoření sekcí v prezentacích**

Chcete‑li přidat sekci, která bude obsahovat snímky v prezentaci, poskytuje Aspose.Slides for C++ metodu **AddSection**, která vám umožní zadat název sekce, kterou chcete vytvořit, a snímek, od kterého sekce začíná. 

Tento ukázkový kód vám ukáže, jak vytvořit sekci v prezentaci v C++:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
    // section1 bude ukončena u newSlide2 a po ní začne section2   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## **Změna názvů sekcí**

Po vytvoření sekce v prezentaci PowerPoint můžete rozhodnout o změně jejího názvu. 

Tento ukázkový kód vám ukáže, jak změnit název sekce v prezentaci v C++ pomocí Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```

## **FAQ**

**Zůstávají sekce zachovány při ukládání do formátu PPT (PowerPoint 97–2003)?**

Ne. Formát PPT nepodporuje metadata sekcí, takže seskupení sekcí se při ukládání do .ppt ztratí.

**Může být celá sekce „skrytá“?**

Ne. Lze skrýt jen jednotlivé snímky. Sekce jako entita nemá stav „skrytá“.

**Mohu rychle najít sekci podle snímku a naopak první snímek sekce?**

Ano. Sekce je jednoznačně definována svým úvodním snímkem; vzhledem k snímku můžete zjistit, do které sekce patří, a pro sekci můžete získat její první snímek.