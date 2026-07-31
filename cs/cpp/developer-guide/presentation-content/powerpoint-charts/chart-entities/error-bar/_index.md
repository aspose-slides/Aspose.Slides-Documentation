---
title: Přizpůsobení chybových pruhů v grafických prezentacích pomocí C++
linktitle: Chybový pruh
type: docs
url: /cs/cpp/error-bar/
keywords:
- chybový pruh
- vlastní hodnota
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak přidávat a přizpůsobovat chybové pruhy v grafech pomocí Aspose.Slides pro C++ — optimalizujte vizualizaci dat v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s chybovými pruhy v grafických prezentacích pomocí Aspose.Slides. Ukazuje, jak přidat chybové pruhy k sérii grafu, nakonfigurovat nastavení chybových pruhů X a Y a použít různé typy hodnot, jako jsou pevné, procentuální a vlastní hodnoty.

Také demonstruje, jak přiřadit vlastní hodnoty chybových pruhů jednotlivým datovým bodům v sérii pomocí odpovídající kolekce datových bodů. Kromě toho článek obsahuje stručné poznámky o tom, jak se chybové pruhy chovají během exportu, jejich kompatibilitu s značkami a popisky dat a kde najít související třídy a výčty v referenční API.

## **Přidání chybových pruhů**
Aspose.Slides for C++ poskytuje jednoduché API pro správu hodnot chybových pruhů. Vzorový kód se použije při použití vlastního typu hodnoty. Pro zadání hodnoty použijte vlastnost **ErrorBarCustomValues** konkrétního datového bodu ve **DataPoints** kolekci série:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Přidejte bublinový graf na požadovaný snímek.
1. Získejte první sérii grafu a nastavte formát chybového pruhu X.
1. Získejte první sérii grafu a nastavte formát chybového pruhu Y.
1. Nastavte hodnoty a formát pruhů.
1. Zapište upravenou prezentaci do souboru PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Přidání vlastních chybových pruhů**
Aspose.Slides for C++ poskytuje jednoduché API pro správu vlastních hodnot chybových pruhů. Vzorový kód se použije, když je vlastnost **IErrorBarsFormat.ValueType** rovna **Custom**. Pro zadání hodnoty použijte vlastnost **ErrorBarCustomValues** konkrétního datového bodu ve **DataPoints** kolekci série:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Přidejte bublinový graf na požadovaný snímek.
1. Získejte první sérii grafu a nastavte formát chybového pruhu X.
1. Získejte první sérii grafu a nastavte formát chybového pruhu Y.
1. Přístup k jednotlivým datovým bodům série a nastavení hodnot chybového pruhu pro konkrétní datový bod série.
1. Nastavte hodnoty a formát pruhů.
1. Zapište upravenou prezentaci do souboru PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **Často kladené otázky**

**Co se stane s chybovými pruhy při exportu prezentace do PDF nebo obrázků?**

Jsou vykresleny jako součást grafu a během konverze zachovány spolu se zbytkem formátování grafu, za předpokladu kompatibilní verze nebo renderu.

**Lze kombinovat chybové pruhy se značkami a popisky dat?**

Ano. Chybové pruhy jsou samostatným prvkem a jsou kompatibilní se značkami a popisky dat; pokud se prvky překrývají, může být nutné upravit formátování.

**Kde najdu seznam vlastností a výčtů pro práci s chybovými pruhy v API?**

V referenční dokumentaci API: třída [ErrorBarsFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/errorbarsformat/) a související výčty [ErrorBarType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/errorbartype/) a [ErrorBarValueType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/errorbarvaluetype/).