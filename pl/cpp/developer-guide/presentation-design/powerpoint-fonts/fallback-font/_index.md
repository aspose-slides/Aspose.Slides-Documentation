---
title: Zarządzaj czcionkami zastępczymi w prezentacjach w C++
linktitle: Czcionka zastępcza
type: docs
weight: 50
url: /pl/cpp/fallback-font/
keywords:
- czcionka zastępcza
- dostępna czcionka
- zamiana glifów
- określenie czcionki
- określenie reguły
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Zobacz, jak Aspose.Slides dla C++ używa czcionek zastępczych, aby tekst był czytelny w prezentacjach PowerPoint i OpenDocument, gdy oryginalne czcionki nie są dostępne."
---
## **Wprowadzenie**

Czcionki zastępcze są używane, gdy czcionka określona dla tekstu jest dostępna w systemie, ale nie zawiera wymaganego glifu. W takim przypadku Aspose.Slides może użyć jednej z określonych czcionek zastępczych, aby zastąpić brakujący glif.

## **Czcionka zastępcza**

Czcionka zastępcza jest używana, gdy czcionka określona dla tekstu jest dostępna w systemie, ale nie zawiera niezbędnego glifu. W takim przypadku można użyć jednej z określonych czcionek zastępczych do zastąpienia glifu.

Aspose.Slides umożliwia tworzenie czcionek zastępczych, dodawanie ich do kolekcji czcionek zastępczych, ustawianie kolekcji czcionek zastępczych dla określonej prezentacji, usuwanie czcionek zastępczych z prezentacji, określanie reguł stosowania czcionek zastępczych i inne.

Aby zapoznać się z tymi funkcjami, użyj poniższych linków:

- [Utwórz czcionkę zastępczą](/slides/pl/cpp/create-fallback-font)
- [Utwórz kolekcję czcionek zastępczych](/slides/pl/cpp/create-fallback-fonts-collection)
- [Renderuj prezentację z czcionką zastępczą](/slides/pl/cpp/render-presentation-with-fallback-font)

## **FAQ**

**Czym różnią się czcionki zastępcze od substytucji czcionek?**

Czcionka zastępcza jest stosowana na poziomie pojedynczego znaku lub zakresu Unicode, gdy podstawowa czcionka nie zawiera konkretnych glifów; wypełnia tylko brakujące znaki. [Substitution](/slides/pl/cpp/font-substitution/) zastępuje brakującą lub niedostępną czcionkę dla całego fragmentu lub części tekstu inną czcionką. Można je łączyć, ale ich zakres i logika wyboru są różne.

**Czy ustawienia czcionek zastępczych są zapisywane w pliku prezentacji?**

Nie. Konfiguracja czcionek zastępczych istnieje w czasie przetwarzania/renderowania w bibliotece i nie jest serializowana do pliku PPTX. Prezentacja nie przechowuje Twoich reguł czcionek zastępczych.

**Czy czcionki zastępcze wpływają na elementy tworzone przez obiekty PowerPoint (SmartArt, wykresy, WordArt)?**

Tak. Tekst wewnątrz tych obiektów przechodzi przez ten sam proces renderowania, więc te same reguły czcionek zastępczych mają zastosowanie zarówno do niego, jak i do zwykłego tekstu.