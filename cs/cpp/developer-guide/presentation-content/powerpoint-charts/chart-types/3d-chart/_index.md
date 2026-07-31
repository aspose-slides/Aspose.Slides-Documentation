---
title: Přizpůsobení 3D grafů v prezentacích pomocí C++
linktitle: 3D graf
type: docs
url: /cs/cpp/3d-chart/
keywords:
- 3D graf
- otočení
- hloubka
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se vytvářet a přizpůsobovat 3-D grafy v Aspose.Slides pro C++, s podporou souborů PPT a PPTX -- zvyšte úroveň svých prezentací ještě dnes."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit 3D graf v Aspose.Slides pomocí konfigurace nastavení `Rotation3D`, jako jsou `RotationX`, `RotationY`, `DepthPercents` a `RightAngleAxes`. Prochází tvorbou prezentace, přidáním 3D grafu s výchozími daty, použitím požadovaných nastavení 3D pohledu a uložením upravené prezentace jako souboru PPTX.

## **Nastavení vlastností RotationX, RotationY a DepthPercents 3D grafu**

Aspose.Slides pro C++ poskytuje jednoduché API pro nastavení těchto vlastností. Následující článek vám pomůže, jak nastavit různé vlastnosti jako X, Y otáčení, **DepthPercents** atd. Vzorový kód ukazuje nastavení výše zmíněných vlastností.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte první snímek.
3. Přidejte graf s výchozími daty.
4. Nastavte vlastnosti Rotation3D.
5. Uložte upravenou prezentaci do souboru PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **Často kladené otázky**

**Které typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s příbuznými 3D typy zpřístupněnými prostřednictvím výčtu [ChartType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/charttype/). Pro přesný a aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/charttype/) v referenci API vaší nainstalované verze.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Graf můžete exportovat do obrázku pomocí [chart API](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/getimage/) nebo [vykreslit celý snímek](/slides/cs/cpp/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, pokud potřebujete dokonalý náhled v pixelech nebo chcete graf vložit do dokumentů, dashboardů či webových stránek bez nutnosti PowerPointu.

**Jak výkonná je tvorba a vykreslování velkých 3D grafů?**

Výkon závisí na objemu dat a vizuální složitosti. Pro nejlepší výsledky držte 3D efekty na minimu, vyhněte se těžkým texturám na stěnách a oblastech grafu, omezte počet datových bodů na sérii, pokud je to možné, a vykreslujte do výstupu s vhodnou velikostí (rozlišení a rozměry), aby odpovídal cílovému displeji nebo požadavkům na tisk.