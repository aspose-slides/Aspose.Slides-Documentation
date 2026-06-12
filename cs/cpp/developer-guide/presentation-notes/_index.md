---
title: Spravovat poznámky prezentace v C++
linktitle: Poznámky k prezentaci
type: docs
weight: 110
url: /cs/cpp/presentation-notes/
keywords:
- poznámky
- snímek s poznámkami
- přidat poznámky
- odstranit poznámky
- styl poznámek
- hlavní poznámky
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Přizpůsobte poznámky k prezentaci pomocí Aspose.Slides pro C++. Bezproblémově pracujte s poznámkami PowerPoint a OpenDocument a zvyšte svou produktivitu."
---
## **Přehled**

Aspose.Slides podporuje odstraňování snímků s poznámkami z prezentace. V tomto tématu představíme tuto funkci, včetně toho, jak odstraňovat poznámky a jak použít styl na snímky s poznámkami v prezentaci. Aspose.Slides vám umožňuje odstranit poznámky z libovolného snímku a také aplikovat stylování na existující poznámky. Vývojáři mohou poznámky odstraňovat následujícími způsoby:

- Odstranit poznámky z konkrétního snímku v prezentaci.
- Odstranit poznámky ze všech snímků v prezentaci.

## **Odstranit poznámky z konkrétního snímku**
Poznámky konkrétního snímku lze odstranit, jak je ukázáno v příkladu níže:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Odstranit poznámky ze všech snímků**
Poznámky ze všech snímků prezentace lze odstranit, jak je ukázáno v příkladu níže:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Přidat styl poznámek**
Vlastnost NotesStyle byla přidána do rozhraní IMasterNotesSlide a třídy MasterNotesSlide. Tato vlastnost určuje styl textu poznámek. Implementace je demonstrována v níže uvedeném příkladu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **Často kladené otázky**

**Která entita API poskytuje přístup k poznámkám konkrétního snímku?**

Poznámky jsou přístupné prostřednictvím správce poznámek snímku: snímek má [NotesSlideManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/notesslidemanager/) a [metodu](https://reference.aspose.com/slides/cs/cpp/aspose.slides/notesslidemanager/get_notesslide/), která vrací objekt poznámek, nebo `null`, pokud žádné poznámky neexistují.

**Existují rozdíly v podpoře poznámek napříč verzemi PowerPointu, se kterými knihovna funguje?**

Knihovna cílí na širokou škálu formátů Microsoft PowerPoint (97 a novější) a ODP; poznámky jsou v těchto formátech podporovány bez závislosti na nainstalované kopii PowerPointu.