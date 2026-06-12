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
description: "Zjistěte, jak pomocí Aspose.Slides pro C++ přidávat a přizpůsobovat chybové pruhy v grafech — optimalizujte vizualizaci dat v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s chybovými pruhy v grafických prezentacích pomocí Aspose.Slides. Ukazuje, jak přidat chybové pruhy do řady grafu, nakonfigurovat nastavení chybových pruhů X a Y a použít různé typy hodnot, jako jsou pevné, procentuální a vlastní hodnoty. Také demonstruje, jak přiřadit vlastní hodnoty chybových pruhů jednotlivým datovým bodům v řadě pomocí odpovídající kolekce datových bodů. Navíc článek obsahuje stručné poznámky o tom, jak se chybové pruhy chovají během exportu, jejich kompatibilitě s značkami a popisky dat a kde najít související třídy a výčty v referenci API.

## **Přidání chybových pruhů**
Aspose.Slides pro C++ poskytuje jednoduché API pro správu hodnot chybových pruhů. Vzorkový kód platí při použití vlastního typu hodnoty. Pro zadání hodnoty použijte vlastnost **ErrorBarCustomValues** konkrétního datového bodu v kolekci **DataPoints** řady:

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Přidejte bublinový graf na požadovaný snímek.
1. Získejte první řadu grafu a nastavte formát chybového pruhu X.
1. Získejte první řadu grafu a nastavte formát chybového pruhu Y.
1. Nastavení hodnot a formátu pruhů.
1. Uložte upravenou prezentaci do souboru PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Přidání vlastních chybových pruhů**
Aspose.Slides pro C++ poskytuje jednoduché API pro správu vlastních hodnot chybových pruhů. Vzorkový kód se používá, když je vlastnost **IErrorBarsFormat.ValueType** rovna **Custom**. Pro zadání hodnoty použijte vlastnost **ErrorBarCustomValues** konkrétního datového bodu v kolekci **DataPoints** řady:

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Přidejte bublinový graf na požadovaný snímek.
1. Získejte první řadu grafu a nastavte formát chybového pruhu X.
1. Získejte první řadu grafu a nastavte formát chybového pruhu Y.
1. Získejte jednotlivé datové body řady grafu a nastavte hodnoty chybového pruhu pro konkrétní datový bod řady.
1. Nastavení hodnot a formátu pruhů.
1. Uložte upravenou prezentaci do souboru PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **FAQ**

**Co se stane s chybovými pruhy při exportu prezentace do PDF nebo obrázků?**

Jsou vykresleny jako součást grafu a během konverze zachovány spolu se zbytkem formátování grafu, za předpokladu kompatibilní verze nebo rendereru.

**Lze chybové pruhy kombinovat se značkami a popisky dat?**

Ano. Chybové pruhy jsou samostatným prvkem a jsou kompatibilní se značkami a popisky dat; pokud se prvky překrývají, může být nutné upravit formátování.

**Kde najdu seznam vlastností a výčtů pro práci s chybovými pruhy v API?**

V referenci API: třída [ErrorBarsFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/errorbarsformat/) a související výčty [ErrorBarType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/errorbartype/) a [ErrorBarValueType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/errorbarvaluetype/).