---
title: Správa poznámek prezentace v C++
linktitle: Poznámky k prezentaci
type: docs
weight: 110
url: /cs/cpp/presentation-notes/
keywords:
- poznámky
- snímek s poznámkami
- přidat poznámky
- odebrat poznámky
- styl poznámek
- hlavní poznámky
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Přizpůsobte si poznámky k prezentaci pomocí Aspose.Slides pro C++. Bez problémů pracujte s poznámkami PowerPoint a OpenDocument a zvyšte svou produktivitu."
---
## **Přehled**

Aspose.Slides podporuje odstraňování snímků s poznámkami z prezentace. V tomto tématu představíme tuto funkci, včetně toho, jak odstranit poznámky a jak použít styl na snímky s poznámkami v prezentaci. Aspose.Slides vám umožňuje odstranit poznámky z libovolného snímku a také aplikovat stylování na existující poznámky. Vývojáři mohou poznámky odstranit následujícími způsoby:

- Odebrat poznámky z konkrétního snímku v prezentaci.
- Odebrat poznámky ze všech snímků v prezentaci.

Pro čtení nebo změnu rozměrů stránky poznámek, přepnutí orientace a kontrolu chování exportu viz [Velikost stránky poznámek](/slides/cs/cpp/notes-size/).

## **Odebrat poznámky z konkrétního snímku**
Poznámky z konkrétního snímku lze odstranit podle příkladu níže:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Odebrat poznámky ze všech snímků**
Poznámky ze všech snímků v prezentaci lze odstranit podle příkladu níže:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Přidat styl poznámek**
V rozhraní IMasterNotesSlide a třídě MasterNotesSlide byla přidána vlastnost NotesStyle. Tato vlastnost určuje styl textu poznámek. Implementace je ukázána v příkladu níže.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **Často kladené otázky**

### Který prvek API poskytuje přístup k poznámkám konkrétního snímku?

Poznámky jsou přístupné přes správce poznámek snímku: snímek má [NotesSlideManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/notesslidemanager/) a [method](https://reference.aspose.com/slides/cs/cpp/aspose.slides/notesslidemanager/get_notesslide/), která vrací objekt poznámek, nebo `null`, pokud poznámky neexistují.

### Existují rozdíly v podpoře poznámek napříč verzemi PowerPointu, se kterými knihovna pracuje?

Knihovna cílí na širokou škálu formátů Microsoft PowerPoint (97 a novější) a ODP; poznámky jsou v těchto formátech podporovány bez nutnosti instalované kopie PowerPointu.