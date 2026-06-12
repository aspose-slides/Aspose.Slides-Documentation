---
title: "Skupinové tvary v prezentaci v C++"
linktitle: "Skupina tvarů"
type: docs
weight: 40
url: /cs/cpp/group/
keywords:
- "skupinový tvar"
- "skupina tvarů"
- "přidat skupinu"
- "alternativní text"
- "PowerPoint"
- "prezentace"
- "C++"
- "Aspose.Slides"
description: "Naučte se seskupovat a rozeskupovat tvary v prezentacích PowerPoint pomocí Aspose.Slides pro C++ — rychlý, krok za krokem průvodce s bezplatným kódem v C++."
---
## **Overview**

Tento článek vysvětluje, jak pracovat s grupovými tvary v Aspose.Slides. Ukazuje, jak přidat grupový tvar na snímek, umístit do něj tvary a uložit aktualizovanou prezentaci. Také demonstruje, jak přistupovat k tvarům uloženým ve skupině a číst jejich hodnoty `AlternativeText`. Navíc článek stručně pokrývá související možnosti grupových tvarů, jako jsou vnořené skupiny, z‑order a možnosti uzamčení.

## **Add a Group Shape**

Aspose.Slides podporuje práci s grupovými tvary na snímcích. Tato funkce pomáhá vývojářům vytvářet bohatší prezentace. Aspose.Slides pro C++ podporuje přidávání nebo přístup k grupovým tvarům. Je možné přidávat tvary do přidaného grupového tvaru, aby byl naplněn, nebo přistupovat k jakékoli jeho vlastnosti. Pro přidání grupového tvaru na snímek pomocí Aspose.Slides pro C++:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
2. Získejte referenci na snímek pomocí jeho Indexu
3. Přidejte grupový tvar na snímek.
4. Přidejte tvary do přidaného grupového tvaru.
5. Uložte upravenou prezentaci jako soubor PPTX.

Níže uvedený příklad přidává grupový tvar na snímek.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **Access the AltText Property**

Toto téma ukazuje jednoduché kroky, doplněné ukázkami kódu, pro přidání grupového tvaru a přístup k vlastnosti AltText grupových tvarů na snímcích. Pro přístup k AltText grupového tvaru na snímku pomocí Aspose.Slides pro C++:

1. Instancujte třídu `Presentation`, která představuje soubor PPTX.
2. Získejte referenci na snímek pomocí jeho Indexu.
3. Přístup k kolekci tvarů snímků.
4. Přístup ke skupinovému tvaru.
5. Přístup k vlastnosti AltText.

Níže uvedený příklad přistupuje k alternativnímu textu grupového tvaru.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **FAQ**

**Je podporováno vnořené seskupování (skupina uvnitř skupiny)?**

Ano. [GroupShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/groupshape/) má metodu [get_ParentGroup](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/get_parentgroup/), která přímo naznačuje podporu hierarchie (skupina může být podřízena jiné skupině).

**Jak mohu řídit z‑order skupiny vzhledem k ostatním objektům na snímku?**

Použijte [GroupShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/groupshape/) vlastnost [Z-Order position](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/get_zorderposition/) k zjištění její pozice v zásobníku zobrazení.

**Mohu zabránit přesunu/editaci/rozbalení skupiny?**

Ano. Sekce zamykání skupiny je přístupná přes [get_GroupShapeLock](https://reference.aspose.com/slides/cs/cpp/aspose.slides/groupshape/get_groupshapelock/), která umožňuje omezit operace nad objektem.