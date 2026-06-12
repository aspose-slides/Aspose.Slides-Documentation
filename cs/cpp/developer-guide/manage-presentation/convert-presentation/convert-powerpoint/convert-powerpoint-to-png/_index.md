---
title: Převod snímků PowerPoint do PNG v C++
linktitle: PowerPoint na PNG
type: docs
weight: 30
url: /cs/cpp/convert-powerpoint-to-png/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint na PNG
- prezentace na PNG
- snímek na PNG
- PPT na PNG
- PPTX na PNG
- uložit PPT jako PNG
- uložit PPTX jako PNG
- exportovat PPT do PNG
- exportovat PPTX do PNG
- C++
- Aspose.Slides
description: "Rychle převádějte prezentace PowerPoint na vysoce kvalitní PNG obrázky pomocí Aspose.Slides pro C++, což zajišťuje přesné a automatizované výsledky."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint do PNG obrázků pomocí Aspose.Slides. Ukazuje, jak načíst soubory prezentací ve formátech jako PPT, PPTX a ODP, vykreslit snímky jako obrázky a uložit výsledky ve formátu PNG.

Článek také demonstruje, jak přizpůsobit generované PNG obrázky nastavením hodnot měřítka nebo zadáním požadované šířky a výšky.

## **Převod PowerPointu do PNG**

Proveďte následující kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Získejte objekt snímku z kolekce [Presentation::get_Slides()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) pod rozhraním [ISlide](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_slide).
3. Použijte metodu [ISlide::GetImage()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/getimage) k získání miniatury pro každý snímek.
4. Použijte metodu [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) k uložení miniatury snímku do formátu PNG.

Tento C++ kód ukazuje, jak převést prezentaci PowerPoint do PNG:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **Převod PowerPointu do PNG s vlastním měřítkem**

Pokud chcete získat PNG soubory s určitým měřítkem, můžete nastavit hodnoty pro `desiredX` a `desiredY`, které určují rozměry výsledné miniatury.

Tento kód v C++ demonstruje popsanou operaci:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **Převod PowerPointu do PNG s vlastní velikostí**

Pokud chcete získat PNG soubory s určitou velikostí, můžete předat preferované argumenty `width` a `height` pro `ImageSize`.

Tento kód ukazuje, jak převést PowerPoint do PNG při zadání velikosti obrázků:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```

## **Často kladené otázky**

**Jak mohu exportovat pouze konkrétní tvar (např. graf nebo obrázek) místo celého snímku?**

Aspose.Slides podporuje [generating thumbnails for individual shapes](/slides/cs/cpp/create-shape-thumbnails/); můžete vykreslit tvar do PNG obrázku.

**Je na serveru podporován paralelní převod?**

Ano, ale [don’t share](/slides/cs/cpp/multithreading/) jednu instanci prezentace napříč vlákny. Použijte samostatnou instanci pro každé vlákno nebo proces.

**Jaká jsou omezení zkušební verze při exportu do PNG?**

Režim hodnocení přidává vodoznak do výstupních obrázků a uplatňuje [other restrictions](/slides/cs/cpp/licensing/) až do aplikace licence.