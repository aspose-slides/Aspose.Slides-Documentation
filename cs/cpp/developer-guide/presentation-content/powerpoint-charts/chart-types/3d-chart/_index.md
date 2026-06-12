---
title: Přizpůsobení 3D grafů v prezentacích pomocí С++
linktitle: 3D graf
type: docs
url: /cs/cpp/3d-chart/
keywords:
- 3D graf
- rotace
- hloubka
- PowerPoint
- prezentace
- С++
- Aspose.Slides
description: "Zjistěte, jak vytvářet a přizpůsobovat 3D grafy v Aspose.Slides pro С++ s podporou souborů PPT a PPTX — vylepšete své prezentace ještě dnes."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit 3D graf v Aspose.Slides konfigurací nastavení `Rotation3D`, jako jsou `RotationX`, `RotationY`, `DepthPercents` a `RightAngleAxes`. Prochází vytvořením prezentace, přidáním 3D grafu s výchozími daty, aplikací požadovaných nastavení 3D zobrazení a uložením upravené prezentace jako souboru PPTX.

## **Nastavení vlastností RotationX, RotationY a DepthPercents 3D grafu**
Aspose.Slides pro C++ poskytuje jednoduché rozhraní API pro nastavení těchto vlastností. Tento článek vám pomůže nastavit různé vlastnosti jako otáčení X, Y, **DepthPercents** atd. Ukázkový kód ukazuje nastavení výše zmíněných vlastností.

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Nastavte vlastnosti Rotation3D.
1. Zapište upravenou prezentaci do souboru PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **FAQ**

**Jaké typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s příbuznými 3D typy, které jsou k dispozici prostřednictvím výčtu [ChartType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/charttype/). Pro přesný a aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/charttype/) v referenci API nainstalované verze.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Můžete exportovat graf jako obrázek pomocí [API grafu](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/getimage/) nebo [vykreslit celý snímek](/slides/cs/cpp/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, pokud potřebujete pixelově přesný náhled nebo chcete graf vložit do dokumentů, dashboardů či webových stránek bez nutnosti PowerPointu.

**Jaká je výkonnost při vytváření a vykreslování velkých 3D grafů?**

Výkonnost závisí na objemu dat a vizuální složitosti. Pro nejlepší výsledky udržujte 3D efekty na minimu, vyhněte se těžkým texturám na stěnách a výsečích, omezte počet datových bodů v sérii, pokud je to možné, a vykreslujte do vhodně dimenzovaného výstupu (rozlišení a rozměry), který odpovídá cílovému zobrazení nebo tisku.