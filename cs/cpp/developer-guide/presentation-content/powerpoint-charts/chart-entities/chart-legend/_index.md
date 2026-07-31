---
title: Přizpůsobení legend grafů v prezentacích pomocí C++
linktitle: Legenda grafu
type: docs
url: /cs/cpp/chart-legend/
keywords:
- legenda grafu
- umístění legendy
- velikost písma
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Přizpůsobte legendy grafů pomocí Aspose.Slides pro C++, abyste optimalizovali prezentace PowerPoint s nastaveným formátováním legend."
---
## **Přehled**

Aspose.Slides poskytuje možnosti přizpůsobení legendy grafu v prezentacích PowerPoint. Tento článek ukazuje, jak umístit a změnit velikost legendy, nastavit velikost písma pro celou legendu a aplikovat formátování na jednotlivou položku legendy.

Také pokrývá několik souvisejících chování v sekci FAQ, včetně použití režimu bez překrytí, aby oblast grafu uvolnila místo pro legendu, umožnění zalamování dlouhých popisků legend nebo použití koncových znaků řádku, a nechání formátování legendy dědit ze schématu motivu prezentace, pokud nejsou nastaveny explicitní barvy, výplně ani písma.

## **Umístění legendy**
Pro nastavení vlastností legendy postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
- Získejte odkaz na snímek.
- Přidejte graf na snímek.
- Nastavte vlastnosti legendy.
- Uložte prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme nastavili pozici a velikost legendy grafu.

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

**Mohu povolit legendu tak, aby graf automaticky vyhradil pro ni místo místo překrytí?**

Ano. Použijte režim bez překrytí ([set_Overlay(false)](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/legend/set_overlay/)); v tomto případě se oblast grafu zmenší, aby uvolnila místo pro legendu.

**Mohu vytvořit vícřádkové popisky legendy?**

Ano. Dlouhé popisky se automaticky zalamují, pokud není dostatek místa; vynucené zalomení řádku je podporováno pomocí znaků nového řádku v názvu řady.

**Jak zajistit, aby legenda používala barevné schéma motivu prezentace?**

Nenastavujte explicitní barvy, výplně ani písma pro legendu nebo její text. Pak budou tyto vlastnosti dědit ze motivu a správně se aktualizují při změně designu.