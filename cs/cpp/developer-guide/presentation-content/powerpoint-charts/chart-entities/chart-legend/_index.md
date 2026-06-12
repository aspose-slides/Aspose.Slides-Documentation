---
title: Přizpůsobení legend grafů v prezentacích pomocí С++
linktitle: Legenda grafu
type: docs
url: /cs/cpp/chart-legend/
keywords:
- legenda grafu
- pozice legendy
- velikost písma
- PowerPoint
- prezentace
- С++
- Aspose.Slides
description: "Přizpůsobte legendy grafů pomocí Aspose.Slides pro С++ a optimalizujte prezentace PowerPoint pomocí upraveného formátování legendy."
---
## **Přehled**

Aspose.Slides poskytuje možnosti přizpůsobení legend grafů v prezentacích PowerPoint. Tento článek ukazuje, jak nastavit umístění a velikost legendy, nastavit velikost písma pro celou legendu a aplikovat formátování na jednotlivou položku legendy.

Také jsou zde zahrnuty související chování v sekci FAQ, včetně použití režimu bez překrytí, aby oblast grafu udělala místo pro legendu, povolení zalamování dlouhých štítků legendy nebo použití konců řádků a umožnění dědění formátování legendy z motivu prezentace, když nejsou nastaveny explicitní nastavení textu a výplně.

## **Umístění legendy**
Chcete‑li nastavit vlastnosti legendy, postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
- Získejte odkaz na snímek.
- Přidejte graf na snímek.
- Nastavte vlastnosti legendy.
- Uložte prezentaci jako soubor PPTX.

V ukázkovém příkladu níže jsme nastavili umístění a velikost legendy grafu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **Nastavení velikosti písma legendy**
Aspose.Slides pro C++ umožňuje vývojářům nastavit velikost písma legendy. Postupujte podle následujících kroků:

- Vytvořte instanci třídy Presentation.
- Vytvořte výchozí graf.
- Nastavte velikost písma.
- Nastavte minimální hodnotu osy.
- Nastavte maximální hodnotu osy.
- Uložte prezentaci na disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **Nastavení velikosti písma jednotlivé položky legendy**
Aspose.Slides pro C++ umožňuje vývojářům nastavit velikost písma jednotlivých položek legendy. Postupujte podle následujících kroků:

- Vytvořte instanci třídy Presentation.
- Vytvořte výchozí graf.
- Získejte přístup k položce legendy.
- Nastavte velikost písma.
- Nastavte minimální hodnotu osy.
- Nastavte maximální hodnotu osy.
- Uložte prezentaci na disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **FAQ**

**Mohu povolit legendu tak, aby graf automaticky vyčlenil místo pro ni místo překrytí?**

Ano. Použijte režim bez překrytí ([set_Overlay(false)](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/legend/set_overlay/)); v tomto případě se oblast vykreslení zmenší, aby poskytla místo legendě.

**Mohu vytvořit vícero řádkové popisky legendy?**

Ano. Dlouhé popisky se automaticky zalamují, pokud není dostatek místa; vynucené zalomení řádku je podporováno pomocí znaků nového řádku ve jménu řady.

**Jak zajistit, aby legenda používala barevné schéma motivu prezentace?**

Nesetrovejte explicitní barvy/výplně/písma pro legendu ani její text. Ty pak zdědí nastavení z motivu a budou se správně aktualizovat při změně designu.