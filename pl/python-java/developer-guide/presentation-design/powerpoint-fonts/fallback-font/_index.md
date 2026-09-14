---
title: Zarządzanie czcionkami zapasowymi w prezentacjach w Pythonie przy użyciu Java
linktitle: Czcionka zapasowa
type: docs
weight: 50
url: /pl/python-java/fallback-font/
keywords:
- czcionka zapasowa
- dostępna czcionka
- zastąpienie glifu
- określenie czcionki
- określenie reguły
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Zobacz, jak Aspose.Slides for Python via Java używa czcionek zapasowych, aby utrzymać czytelność tekstu w prezentacjach PowerPoint i OpenDocument, gdy oryginalne czcionki nie są dostępne."
---
## **Wprowadzenie**

Czcionki zapasowe są używane, gdy czcionka określona dla tekstu jest dostępna w systemie, ale nie zawiera wymaganego glifu. W takim przypadku Aspose.Slides może użyć jednej z określonych czcionek zapasowych, aby zastąpić brakujący glif.

## **Czcionka zapasowa**

Aspose.Slides umożliwia tworzenie czcionek zapasowych, dodawanie ich do kolekcji czcionek zapasowych, ustawianie kolekcji czcionek zapasowych dla określonej prezentacji, usuwanie czcionek zapasowych z prezentacji, określanie reguł stosowania czcionek zapasowych oraz wykonywanie innych powiązanych operacji.

Aby zapoznać się z tymi funkcjami, użyj poniższych linków:

- [Utwórz czcionkę zapasową](/slides/pl/python-java/create-fallback-font/)
- [Utwórz kolekcję czcionek zapasowych](/slides/pl/python-java/create-fallback-fonts-collection/)
- [Renderuj prezentację z czcionką zapasową](/slides/pl/python-java/render-presentation-with-fallback-font/)

## **FAQ**

**Czym różnią się czcionki zapasowe od zamiany czcionek?**

Czcionki zapasowe są stosowane znak po znaku lub w zakresie Unicode, gdy podstawowa czcionka nie posiada określonych glifów; wypełniają tylko brakujące znaki. [Zamiana](/slides/pl/python-java/font-substitution/) zastępuje brakującą lub niedostępną czcionkę w całym ciągu znaków lub fragmencie tekstu inną czcionką. Mogą być łączone, ale ich zakres i logika wyboru są różne.

**Czy ustawienia czcionek zapasowych są zapisywane w pliku prezentacji?**

Nie. Konfiguracja czcionek zapasowych istnieje w czasie przetwarzania/renderowania w bibliotece i nie jest serializowana do pliku PPTX. Prezentacja nie przechowuje Twoich reguł czcionek zapasowych.

**Czy czcionki zapasowe wpływają na elementy tworzone przez obiekty PowerPoint (SmartArt, wykresy, WordArt)?**

Tak. Tekst wewnątrz tych obiektów przechodzi przez ten sam proces renderowania, więc te same reguły czcionek zapasowych mają zastosowanie zarówno do niego, jak i do zwykłego tekstu.