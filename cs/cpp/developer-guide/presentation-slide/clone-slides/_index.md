---
title: Klonovat snímky prezentace v C++
linktitle: Klonovat snímky
type: docs
weight: 40
url: /cs/cpp/clone-slides/
keywords:
- klonovat snímek
- kopírovat snímek
- uložit snímek
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Rychle duplikujte snímky PowerPoint pomocí Aspose.Slides pro C++. Sledujte naše přehledné ukázky kódu, abyste během několika sekund automatizovali tvorbu PPT a odstranili ruční práci."
---
## **Úvod**

Klonování je proces vytvoření přesné kopie nebo repliky něčeho. Aspose.Slides for C++ také umožňuje vytvořit kopii nebo klon libovolného snímku a následně vložit tento klonovaný snímek do aktuální nebo jiné otevřené prezentace. Proces klonování snímku vytváří nový snímek, který mohou vývojáři upravovat, aniž by měnili původní snímek. Existuje několik možných způsobů, jak klonovat snímek:

- Klonovat na konci v rámci prezentace.
- Klonovat na jiném místě v rámci prezentace.
- Klonovat na konci v jiné prezentaci.
- Klonovat na jiném místě v jiné prezentaci.
- Klonovat na konkrétním místě v jiné prezentaci.

V Aspose.Slides for C++ (kolekce objektů [ISlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/) ) zpřístupněná objektem [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) poskytuje metody [AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) a [InsertClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/insertclone/) pro provádění výše uvedených typů klonování snímků

## **Klonovat snímek na konci prezentace**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace na konci existujících snímků, použijte metodu [AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) podle kroků uvedených níže:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Načtěte třídu [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/) odkazem na kolekci Slides, kterou zpřístupňuje objekt [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Zavolejte metodu [AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) zpřístupněnou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/) a předávejte snímek, který se má klonovat, jako parametr metody [AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/).
1. Zapište upravený soubor prezentace.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se na první pozici – index nula – prezentace) na konec prezentace.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}


## **Klonovat snímek na jiné místo v rámci prezentace**
 in Presentation**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace, ale na jiném místě, použijte metodu [InsertClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/insertclone/):

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Načtěte třídu odkazem na **Slides** kolekci zpřístupněnou objektem [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Zavolejte metodu [InsertClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/insertclone/) zpřístupněnou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/) a předávejte snímek, který se má klonovat, spolu s indexem pro novou pozici jako parametr metody [InsertClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/insertclone/).
1. Zapište upravený soubor prezentace jako PPTX.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se na indexu nula – pozice 1 – prezentace) na index 1 – pozice 2 – prezentace.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Klonovat snímek na konci jiné prezentace**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné prezentaci, na konci existujících snímků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) obsahující prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) obsahující cílovou prezentaci, do které bude snímek přidán.
1. Načtěte třídu [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/) odkazem na **Slides** kolekci zpřístupněnou objektem Presentation cílové prezentace.
1. Zavolejte metodu [AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) zpřístupněnou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/) a předávejte snímek ze zdrojové prezentace jako parametr metody [AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/).
1. Zapište upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z prvního indexu zdrojové prezentace) na konec cílové prezentace.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Klonovat snímek na jiné místo v jiné prezentaci**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné prezentaci, na konkrétní pozici:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) obsahující zdrojovou prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) obsahující prezentaci, do které bude snímek přidán.
1. Načtěte třídu [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/) odkazem na Slides kolekci zpřístupněnou objektem Presentation cílové prezentace.
1. Zavolejte metodu [InsertClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/insertclone/) zpřístupněnou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/) a předávejte snímek ze zdrojové prezentace spolu s požadovanou pozicí jako parametr metody [InsertClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/insertclone/).
1. Zapište upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z indexu nula zdrojové prezentace) na index 1 (pozice 2) cílové prezentace.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}
## **Klonovat snímek na konkrétním místě v jiné prezentaci**
Pokud potřebujete klonovat snímek s hlavním snímkem z jedné prezentace a použít jej v jiné prezentaci, nejprve musíte klonovat požadovaný hlavní snímek ze zdrojové prezentace do cílové prezentace. Poté použijete tento hlavní snímek pro klonování snímku s hlavním snímkem. Metoda **AddClone(ISlide, IMasterSlide)** očekává hlavní snímek z cílové prezentace, nikoli ze zdrojové. Pro klonování snímku s hlavním snímkem postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) obsahující zdrojovou prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) obsahující cílovou prezentaci, do které bude snímek klonován.
1. Přistupte ke snímku, který má být klonován, spolu s hlavním snímkem.
1. Načtěte třídu [IMasterSlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslidecollection/) odkazem na kolekci Masters zpřístupněnou objektem [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) cílové prezentace.
1. Zavolejte metodu [AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) zpřístupněnou objektem [IMasterSlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslidecollection/) a předávejte hlavní snímek ze zdrojového PPTX jako parametr metody [AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/).
1. Načtěte třídu [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/) nastavením odkazu na kolekci Slides zpřístupněnou objektem [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) cílové prezentace.
1. Zavolejte metodu [AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) zpřístupněnou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/) a předávejte snímek ze zdrojové prezentace k vkládání a hlavní snímek jako parametr metody [AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/).
1. Zapište upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek s hlavním snímkem (nacházející se na indexu nula zdrojové prezentace) na konec cílové prezentace pomocí hlavního snímku ze zdrojového snímku.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}
## **Klonovat snímek na konci určené sekce**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace, ale v jiné sekci, použijte metodu [**AddClone()**](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) zpřístupněnou rozhraním [**ISlideCollection**](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/). Aspose.Slides for C++ umožňuje klonovat snímek z první sekce a následně vložit tento klonovaný snímek do druhé sekce stejné prezentace.

Následující úryvek kódu ukazuje, jak klonovat snímek a vložit jej do určené sekce.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **Časté dotazy**

**Klonují se poznámky přednášejícího a komentáře recenzentů?**

Ano. Stránka poznámek a recenzní komentáře jsou zahrnuty do klonu. Pokud je nechcete, [odeberte je](/slides/cs/cpp/presentation-notes/) po vložení.

**Jak jsou zpracovány grafy a jejich datové zdroje?**

Objekt grafu, formátování a vložená data jsou zkopírována. Pokud byl graf propojen s externím zdrojem (např. se sešitem vloženým jako OLE), zachová se odkaz jako [OLE objekt](/slides/cs/cpp/manage-ole/). Po přesunu mezi soubory ověřte dostupnost dat a chování aktualizace.

**Mohu kontrolovat pozici vložení a sekce pro klon?**

Ano. Můžete vložit klon na konkrétní index snímku a umístit jej do vybrané [sekce](/slides/cs/cpp/slide-section/). Pokud cílová sekce neexistuje, nejprve ji vytvořte a poté do ní snímek přesuňte.