---
title: Efektivně sloučit prezentace v C++
linktitle: Sloučit prezentace
type: docs
weight: 40
url: /cs/cpp/merge-presentation/
keywords:
- sloučit PowerPoint
- sloučit prezentace
- sloučit snímky
- sloučit PPT
- sloučit PPTX
- sloučit ODP
- kombinovat PowerPoint
- kombinovat prezentace
- kombinovat snímky
- kombinovat PPT
- kombinovat PPTX
- kombinovat ODP
- C++
- Aspose.Slides
description: "Bez námahy sloučte prezentace PowerPoint (PPT, PPTX) a OpenDocument (ODP) pomocí Aspose.Slides pro C++, zefektivníte svůj pracovní postup."
---
## **Přehled**

Aspose.Slides vám umožňuje sloučit prezentace klonováním snímků z jedné prezentace do druhé. Tento článek vysvětluje, jak sloučit celé prezentace nebo vybrané snímky, použít hlavní snímek nebo konkrétní rozvržení během sloučení, pracovat s prezentacemi s různými velikostmi snímků a přidat sloučené snímky do sekce prezentace. Také pokrývá praktické poznámky související se sloučeným obsahem, včetně poznámek přednášejícího, komentářů, souborů chráněných heslem a používání vláken.

## **Sloučení prezentací**

Když sloučíte jednu prezentaci s jinou, v podstatě kombinujete jejich snímky v jedné prezentaci a získáte jeden soubor. 

{{% alert title="Info" color="info" %}}

Většina programů pro prezentace (PowerPoint nebo OpenOffice) postrádá funkce, které uživatelům umožňují kombinovat prezentace tímto způsobem. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/cs/cpp/), však umožňuje sloučit prezentace různými způsoby. Můžete sloučit prezentace se všemi jejich tvary, styly, texty, formátováním, komentáři, animacemi atd., aniž byste se museli obávat ztráty kvality nebo dat. 

**Viz také**

[Clone Slides](https://docs.aspose.com/slides/cs/cpp/clone-slides/)*.* 

{{% /alert %}}

### **Co lze sloučit**

S Aspose.Slides můžete sloučit 

* celé prezentace. Všechny snímky z prezentací skončí v jedné prezentaci
* konkrétní snímky. Vybrané snímky skončí v jedné prezentaci
* prezentace v jednom formátu (PPT na PPT, PPTX na PPTX atd.) i v různých formátech (PPT na PPTX, PPTX na ODP atd.) mezi sebou. 

{{% alert title="Poznámka" color="warning" %}} 

Kromě prezentací umožňuje Aspose.Slides sloučit i jiné soubory:

* [Images](https://products.aspose.com/slides/cs/cpp/merger/image-to-image/), například [JPG to JPG](https://products.aspose.com/slides/cs/cpp/merger/jpg-to-jpg/) nebo [PNG to PNG](https://products.aspose.com/slides/cs/cpp/merger/png-to-png/)
* Dokumenty, například [PDF to PDF](https://products.aspose.com/slides/cs/cpp/merger/pdf-to-pdf/) nebo [HTML to HTML](https://products.aspose.com/slides/cs/cpp/merger/html-to-html/)
* A dva rozdílné soubory, například [image to PDF](https://products.aspose.com/slides/cs/cpp/merger/image-to-pdf/) nebo [JPG to PDF](https://products.aspose.com/slides/cs/cpp/merger/jpg-to-pdf/) nebo [TIFF to PDF](https://products.aspose.com/slides/cs/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Možnosti sloučení**

Můžete použít možnosti, které určují, zda

* každý snímek ve výstupní prezentaci zachová jedinečný styl
* pro všechny snímky ve výstupní prezentaci bude použit jeden konkrétní styl. 

Pro sloučení prezentací poskytuje Aspose.Slides metody [AddClone](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (z rozhraní [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_slide_collection)). Existuje několik implementací metod `AddClone`, které definují parametry procesu sloučení prezentací. Každý objekt Presentation má kolekci [Slides](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), takže můžete zavolat metodu `AddClone` z prezentace, do které chcete snímky sloučit. 

Metoda `AddClone` vrací objekt `ISlide`, což je klon zdrojového snímku. Snímky ve výstupní prezentaci jsou jednoduše kopií snímků ze zdroje. Proto můžete měnit výsledné snímky (například aplikovat styly, formátování nebo rozvržení) aniž byste ovlivnili původní prezentace. 

## **Sloučení prezentací** 

Aspose.Slides poskytuje metodu [**AddClone (ISlide)**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee), která umožňuje kombinovat snímky tak, aby snímky zachovaly svá rozvržení a styly (výchozí parametry). 

Tento kód v C++ ukazuje, jak sloučit prezentace:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Sloučení prezentací s hlavním snímkem**

Aspose.Slides poskytuje metodu [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640), která umožňuje kombinovat snímky při aplikaci šablony hlavního snímku. Tímto způsobem můžete v případě potřeby změnit styl snímků ve výstupní prezentaci. 

Tento kód v C++ demonstruje popsanou operaci:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Poznámka" color="warning" %}} 

Rozvržení snímku pro hlavní snímek je určeno automaticky. Pokud není možné vhodné rozvržení určit, a parametr `allowCloneMissingLayout` metody `AddClone` je nastaven na true, použije se rozvržení zdrojového snímku. V opačném případě bude vyhozena výjimka [PptxEditException](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 

{{% /alert %}}

Pokud chcete, aby snímky ve výstupní prezentaci měly jiné rozvržení, použijte při sloučení metodu [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1). 

## **Sloučení konkrétních snímků z prezentací**

Sloučení konkrétních snímků z více prezentací je užitečné při tvorbě vlastních balíčků snímků. Aspose.Slides C++ umožňuje vybrat a importovat pouze snímky, které potřebujete. API zachovává formátování, rozvržení i design původních snímků.

Následující kód v C++ vytvoří novou prezentaci, přidá titulní snímky ze dvou dalších prezentací a uloží výsledek do souboru:

```cpp
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **Sloučení prezentací s rozvržením snímku**

Tento kód v C++ ukazuje, jak kombinovat snímky z prezentací při aplikaci vámi preferovaného rozvržení snímku, abyste získali jednu výstupní prezentaci:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Sloučení prezentací s různými velikostmi snímků**

{{% alert title="Poznámka" color="warning" %}} 

Nelze sloučit prezentace s různými velikostmi snímků. 

{{% /alert %}}

Chcete-li sloučit 2 prezentace s různými velikostmi snímků, musíte velikost jedné z prezentací změnit tak, aby odpovídala velikosti druhé. 

Tento ukázkový kód demonstruje popsanou operaci:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Sloučení snímků do sekce prezentace**

Tento kód v C++ ukazuje, jak sloučit konkrétní snímek do sekce v prezentaci:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

Snímek je přidán na konec sekce. 

{{% alert title="Tip" color="primary" %}}

Aspose poskytuje [FREE Collage web app](https://products.aspose.app/slides/cs/collage). Pomocí této online služby můžete sloučit [JPG to JPG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG na PNG obrázky, vytvořit [photo grids](https://products.aspose.app/slides/cs/collage/photo-grid) a podobně. 

{{% /alert %}}

## **FAQ**

**Jsou poznámky přednášejícího zachovány při sloučení?**

Ano. Při klonování snímků Aspose.Slides přenáší všechny prvky snímku, včetně poznámek, formátování a animací.

**Přenesou se komentáře a jejich autoři?**

Komentáře, jako součást obsahu snímku, jsou zkopírovány se snímkem. Štítky autorů komentářů jsou zachovány jako objekty komentářů ve výsledné prezentaci.

**Co když je zdrojová prezentace chráněna heslem?**

Musí být [otevřena s heslem](/slides/cs/cpp/password-protected-presentation/) pomocí [LoadOptions::set_Password](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_password/); po načtení lze tyto snímky bezpečně klonovat do nechráněného cílového souboru (nebo také do chráněného).

**Jak je operace sloučení bezpečná pro vlákna?**

Neužívejte stejnou [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) instanci z [více vláken](/slides/cs/cpp/multithreading/). Doporučené pravidlo je „jeden dokument — jedno vlákno“; různé soubory lze zpracovávat paralelně v samostatných vláknech.