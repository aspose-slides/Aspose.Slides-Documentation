---
title: Zarządzanie czcionkami zapasowymi dla prezentacji w C++
linktitle: Czcionka zapasowa
type: docs
weight: 50
url: /pl/cpp/fallback-font/
keywords:
- czcionka zapasowa
- dostępna czcionka
- zamiana glifu
- określenie czcionki
- określenie reguły
- PowerPoint
- OpenDocument
- prezentacja
- С++
- Aspose.Slides
description: "Zobacz, jak Aspose.Slides dla C++ używa czcionek zapasowych, aby tekst był czytelny w prezentacjach PowerPoint i OpenDocument, gdy oryginalne czcionki nie są dostępne."
---
## **Wstęp**

Czcionki zapasowe są używane, gdy czcionka określona dla tekstu jest dostępna w systemie, ale nie zawiera wymaganego glifu. W takim przypadku Aspose.Slides może użyć jednej z określonych czcionek zapasowych do zastąpienia brakującego glifu.

## **Czcionka zapasowa**
Czcionka zapasowa jest używana, gdy czcionka określona dla tekstu jest dostępna w systemie, ale nie zawiera wymaganego glifu. W takim przypadku można użyć jednej z określonych czcionek zapasowych do zastąpienia glifu.

Aspose.Slides umożliwia tworzenie czcionek zapasowych, dodawanie ich do kolekcji czcionek zapasowych, ustawianie kolekcji czcionek zapasowych dla określonej prezentacji, usuwanie czcionek zapasowych z prezentacji, określanie reguł stosowania czcionek zapasowych i inne.

Aby zapoznać się z tymi funkcjami, skorzystaj z poniższych linków:

- [Utwórz czcionkę zapasową](/slides/pl/cpp/create-fallback-font)
- [Utwórz kolekcję czcionek zapasowych](/slides/pl/cpp/create-fallback-fonts-collection)
- [Renderuj prezentację z czcionką zapasową](/slides/pl/cpp/render-presentation-with-fallback-font)

## **FAQ**

**Czym różnią się czcionki zapasowe od substytucji czcionek?**

Czcionka zapasowa jest stosowana dla każdego znaku lub zakresu Unicode, gdy podstawowa czcionka nie zawiera określonych glifów; uzupełnia jedynie brakujące znaki. [Substitucja](/slides/pl/cpp/font-substitution/) zastępuje brakującą lub niedostępną czcionkę dla całego fragmentu lub części tekstu inną czcionką. Mogą być łączone, ale ich zakres i logika wyboru są różne.

**Czy ustawienia czcionek zapasowych są zapisywane w pliku prezentacji?**

Nie. Konfiguracja czcionek zapasowych istnieje w czasie przetwarzania/renderowania w bibliotece i nie jest serializowana do pliku PPTX. Prezentacja nie przechowuje Twoich reguł czcionek zapasowych.

**Czy czcionki zapasowe wpływają na elementy utworzone przez obiekty PowerPoint (SmartArt, wykresy, WordArt)?**

Tak. Tekst wewnątrz tych obiektów przechodzi przez ten sam proces renderowania, więc te same reguły czcionek zapasowych mają zastosowanie zarówno do niego, jak i do zwykłego tekstu.