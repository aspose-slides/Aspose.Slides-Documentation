---
title: Zarządzanie czcionkami zastępczymi w prezentacjach w Pythonie
linktitle: Czcionka zastępcza
type: docs
weight: 50
url: /pl/python-net/fallback-font/
keywords:
- czcionka zastępcza
- dostępna czcionka
- zamiana glifów
- określenie czcionki
- określenie reguły
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Zobacz, jak Aspose.Slides dla Pythona via .NET używa czcionek zastępczych, aby tekst był czytelny w prezentacjach PowerPoint i OpenDocument, gdy oryginalne czcionki nie są dostępne."
---
## **Wstęp**

Czcionki zastępcze są używane, gdy czcionka określona dla tekstu jest dostępna w systemie, ale nie zawiera wymaganego glifu. W takim przypadku Aspose.Slides może użyć jednej z określonych czcionek zastępczych, aby zastąpić brakujący glif.

## **Czcionka zastępcza**

Aspose.Slides umożliwia tworzenie czcionek zastępczych, dodawanie ich do kolekcji czcionek zastępczych, ustawianie kolekcji czcionek zastępczych dla określonej prezentacji, usuwanie czcionek zastępczych z prezentacji, określanie reguł zastosowania czcionek zastępczych i inne.

Aby zapoznać się z tymi funkcjami, użyj poniższych linków:

- [Utwórz czcionkę zastępczą](/slides/pl/python-net/create-fallback-font)
- [Utwórz kolekcję czcionek zastępczych](/slides/pl/python-net/create-fallback-fonts-collection)
- [Renderuj prezentację z czcionką zastępczą](/slides/pl/python-net/render-presentation-with-fallback-font)

## **FAQ**

**Czym różnią się czcionki zastępcze od podstawiania czcionek?**

Czcionka zastępcza jest stosowana na poziomie pojedynczego znaku lub zakresu Unicode, gdy podstawowa czcionka nie posiada określonych glifów; uzupełnia jedynie brakujące znaki. [Podstawianie](/slides/pl/python-net/font-substitution/) zastępuje brakującą lub niedostępną czcionkę dla całego ciągu lub fragmentu tekstu inną czcionką. Mogą być łączone, ale ich zakres i logika wyboru są różne.

**Czy ustawienia czcionek zastępczych są zapisywane w pliku prezentacji?**

Nie. Konfiguracja czcionek zastępczych istnieje w czasie przetwarzania/renderowania w bibliotece i nie jest serializowana do pliku PPTX. Prezentacja nie przechowuje twoich reguł czcionek zastępczych.

**Czy czcionki zastępcze wpływają na elementy tworzone przez obiekty PowerPoint (SmartArt, wykresy, WordArt)?**

Tak. Tekst wewnątrz tych obiektów przechodzi przez ten sam proces renderowania, więc te same reguły czcionek zastępczych mają zastosowanie zarówno do niego, jak i do zwykłego tekstu.