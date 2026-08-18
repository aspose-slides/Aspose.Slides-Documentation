---
title: Klonování snímků prezentace v C++
linktitle: Klonovat snímky
type: docs
weight: 40
url: /cs/cpp/clone-slides/
keywords:
- klonování snímku
- kopírovat snímek
- uložit snímek
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Rychle duplikujte snímky PowerPointu pomocí Aspose.Slides pro C++. Sledujte naše přehledné ukázky kódu a automatizujte tvorbu PPT během několika sekund a odstraňte ruční práci."
---
## **Úvod**

Klónování je proces vytváření přesné kopie nebo repliky něčeho. Aspose.Slides pro C++ také umožňuje vytvořit kopii nebo klon libovolného snímku a poté vložit tento klonovaný snímek do aktuální nebo jiné otevřené prezentace. Proces klonování snímku vytvoří nový snímek, který mohou vývojáři upravovat, aniž by změnili původní snímek. Existuje několik možných způsobů, jak klonovat snímek:

- Klonovat na konci v rámci prezentace.
- Klonovat na jiné pozici v prezentaci.
- Klonovat na konci v jiné prezentaci.
- Klonovat na jiné pozici v jiné prezentaci.
- Klonovat na konkrétní pozici v jiné prezentaci.

V Aspose.Slides pro C++ (kolekce objektů [ISlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/) ) vystavená objektem [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) poskytuje metody [AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) a [InsertClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/insertclone/), které provádějí výše uvedené typy klonování snímků

## **Klonování snímku na konci prezentace**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace na konci existujících snímků, použijte metodu [AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Vytvořte instanci třídy [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/) odkazem na kolekci Slides, která je vystavena objektem [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
3. Zavolejte metodu [AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/) a jako parametr předáte snímek, který má být klonován.
4. Uložte upravený soubor prezentace.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se na první pozici – index nula – prezentace) na konec prezentace.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Klonování snímku na jinou pozici v rámci prezentace**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace, ale na jiné pozici, použijte metodu [InsertClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/insertclone/):

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte instanci třídy odkazem na kolekci **Slides**, která je vystavena objektem [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
3. Zavolejte metodu [InsertClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/insertclone/) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/) a jako parametry předáte snímek, který má být klonován, a index nové pozice.
4. Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se na indexu nula – pozice 1 – prezentace) na index 1 – pozice 2 – prezentace.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Klonování snímku na konci jiné prezentace**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné souboru prezentace, na konci existujících snímků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/), která obsahuje prezentaci, ze které bude snímek klonován.
2. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/), která obsahuje cílovou prezentaci, do které bude snímek přidán.
3. Získejte instanci třídy [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/) odkazem na kolekci **Slides**, která je vystavena objektem Presentation cílové prezentace.
4. Zavolejte metodu [AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/) a jako parametr předáte snímek ze zdrojové prezentace.
5. Uložte upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z první indexu zdrojové prezentace) na konec cílové prezentace.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Klonování snímku na jinou pozici v jiné prezentaci**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné souboru prezentace, na konkrétní pozici:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/), která obsahuje zdrojovou prezentaci, ze které bude snímek klonován.
2. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/), která obsahuje prezentaci, do které bude snímek přidán.
3. Získejte instanci třídy [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/) odkazem na kolekci Slides vystavenou objektem Presentation cílové prezentace.
4. Zavolejte metodu [InsertClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/insertclone/) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/), a jako parametry předáte snímek ze zdrojové prezentace a požadovanou pozici.
5. Uložte upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z indexu nula zdrojové prezentace) na index 1 (pozice 2) cílové prezentace.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Klonování snímku na konkrétní pozici v jiné prezentaci**
Pokud potřebujete klonovat snímek s hlavním snímkem (master slide) z jedné prezentace a použít jej v jiné prezentaci, musíte nejprve klonovat požadovaný hlavní snímek ze zdrojové prezentace do cílové prezentace. Poté použijete tento hlavní snímek při klonování snímku s hlavním snímkem. Metoda **AddClone(ISlide, IMasterSlide)** očekává hlavní snímek z cílové prezentace, nikoli ze zdrojové. Pro klonování snímku s hlavním snímkem postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/), která obsahuje zdrojovou prezentaci, ze které bude snímek klonován.
2. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/), která obsahuje cílovou prezentaci, do které bude snímek klonován.
3. Získejte přístup k snímku, který má být klonován, spolu s hlavním snímkem.
4. Vytvořte instanci třídy [IMasterSlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslidecollection/) odkazem na kolekci Masters, která je vystavena objektem [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) cílové prezentace.
5. Zavolejte metodu [AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) vystavenou objektem [IMasterSlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslidecollection/) a jako parametr předáte hlavní snímek ze zdrojového PPTX, který má být klonován.
6. Vytvořte instanci třídy [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/) nastavením odkazu na kolekci Slides vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/), cílové prezentace.
7. Zavolejte metodu [AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/) a jako parametry předáte snímek ze zdrojové prezentace, který má být klonován, a hlavní snímek.
8. Uložte upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek s hlavním snímkem (nacházející se na indexu nula zdrojové prezentace) na konec cílové prezentace pomocí hlavního snímku ze zdrojového snímku.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Klonování snímku na konci specifikované sekce**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace, ale v jiné sekci, použijte metodu [**AddClone()**](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) vystavenou rozhraním [**ISlideCollection**](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/). Aspose.Slides pro C++ umožňuje klonovat snímek z první sekce a poté vložit tento klonovaný snímek do druhé sekce stejné prezentace.

Následující úryvek kódu ukazuje, jak klonovat snímek a vložit klonovaný snímek do určené sekce.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **Zajistěte shodu velikosti snímků**

Při klonování snímků do jiné prezentace se ujistěte, že cílová prezentace má stejnou velikost snímku jako zdrojová. Pokud se velikosti snímků liší, Aspose.Slides automaticky nepřepočítává velikost klonovaných tvarů – jejich původní souřadnice a rozměry zůstávají zachovány, což může způsobit, že obsah bude nesprávně zarovnán nebo přesahovat hranice snímku.

Můžete nastavit velikost snímku cílové prezentace tak, aby odpovídala zdrojové, předtím než klonujete hlavní snímek a snímek:

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

Udělejte to před klonováním hlavního snímku a snímku.

## **FAQ**

**Klony zahrnují poznámky řečníka a komentáře recenzenta?**

Ano. Stránka s poznámkami a komentáře recenzenta jsou součástí klonu. Pokud je nechcete, [odstraňte je](/slides/cs/cpp/presentation-notes/) po vložení.

**Jak jsou zpracovány grafy a jejich datové zdroje?**

Objekt grafu, jeho formátování a vložená data jsou zkopírovány. Pokud byl graf propojen s externím zdrojem (např. se sešitem vloženým jako OLE), toto propojení je zachováno jako [OLE objekt](/slides/cs/cpp/manage-ole/). Po přesunu mezi soubory ověřte dostupnost dat a chování aktualizace.

**Mohu ovládat pozici vložení a sekce pro klon?**

Ano. Klon můžete vložit na konkrétní index snímku a umístit jej do vybrané [sekce](/slides/cs/cpp/slide-section/). Pokud cílová sekce neexistuje, nejprve ji vytvořte a poté do ní snímek přesuňte.