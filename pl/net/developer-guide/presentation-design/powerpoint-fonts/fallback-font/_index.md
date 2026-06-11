---
title: Zarządzanie czcionkami rezerwowymi dla prezentacji w .NET
linktitle: Czcionka rezerwowa
type: docs
weight: 50
url: /pl/net/fallback-font/
keywords:
- czcionka rezerwowa
- dostępna czcionka
- zamiana glifu
- określenie czcionki
- określenie reguły
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zobacz, jak Aspose.Slides dla .NET używa czcionek rezerwowych, aby tekst był czytelny w prezentacjach PowerPoint i OpenDocument, gdy oryginalne czcionki nie są dostępne."
---
## **Wprowadzenie**

Czcionki rezerwowe są używane, gdy czcionka określona dla tekstu jest dostępna w systemie, ale nie zawiera wymaganego glifu. W takim przypadku Aspose.Slides może użyć jednej z określonych czcionek rezerwowych, aby zamienić brakujący glif.

## **Czcionka rezerwowa**

Aspose.Slides umożliwia tworzenie czcionek rezerwowych, dodawanie ich do kolekcji czcionek rezerwowych, ustawianie kolekcji czcionek rezerwowych dla określonej prezentacji, usuwanie czcionek rezerwowych z prezentacji, określanie reguł stosowania czcionek rezerwowych i inne.

Aby zapoznać się z tymi funkcjami, użyj poniższych linków:

- [Utwórz czcionkę rezerwową](/slides/pl/net/create-fallback-font)
- [Utwórz kolekcję czcionek rezerwowych](/slides/pl/net/create-fallback-fonts-collection)
- [Renderuj prezentację z czcionką rezerwową](/slides/pl/net/render-presentation-with-fallback-font)

## **FAQ**

**Jak czcionki rezerwowe różnią się od podstawiania czcionek?**

Czcionka rezerwowa jest stosowana na poziomie pojedynczego znaku lub zakresu Unicode, gdy podstawowa czcionka nie posiada konkretnych glifów; wypełnia jedynie brakujące znaki. [Podstawienie](/slides/pl/net/font-substitution/) zastępuje brakującą lub niedostępną czcionkę dla całego ciągu lub fragmentu tekstu inną czcionką. Mogą być łączone, ale ich zakres i logika wyboru różnią się.

**Czy ustawienia czcionek rezerwowych są zapisywane w pliku prezentacji?**

Nie. Konfiguracja czcionek rezerwowych istnieje w czasie przetwarzania/renderowania w bibliotece i nie jest serializowana do pliku PPTX. Prezentacja nie przechowuje Twoich reguł czcionek rezerwowych.

**Czy czcionki rezerwowe wpływają na elementy tworzone przez obiekty PowerPoint (SmartArt, wykresy, WordArt)?**

Tak. Tekst wewnątrz tych obiektów przechodzi przez ten sam kanał renderowania, więc te same reguły czcionek rezerwowych mają zastosowanie zarówno do niego, jak i do zwykłego tekstu.