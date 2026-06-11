---
title: Zarządzanie czcionkami zapasowymi dla prezentacji w Javie
linktitle: Czcionka zapasowa
type: docs
weight: 50
url: /pl/java/fallback-font/
keywords:
- czcionka zapasowa
- dostępna czcionka
- zastąpienie glifu
- określenie czcionki
- określenie reguły
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Zobacz, jak Aspose.Slides for Java używa czcionek zapasowych, aby tekst był czytelny w prezentacjach PowerPoint i OpenDocument, gdy oryginalne czcionki nie są dostępne."
---
## **Wstęp**

Czcionki zapasowe są używane, gdy określona dla tekstu czcionka jest dostępna w systemie, ale nie zawiera wymaganego glifu. W takim przypadku Aspose.Slides może użyć jednej z określonych czcionek zapasowych, aby zastąpić brakujący glif.

## **Czcionka zapasowa**

Aspose.Slides umożliwia tworzenie czcionek zapasowych, dodawanie ich do kolekcji czcionek zapasowych, ustawianie kolekcji czcionek zapasowych dla określonej prezentacji, usuwanie czcionek zapasowych z prezentacji, definiowanie reguł stosowania czcionek zapasowych i inne.

Aby zapoznać się z tymi funkcjami, użyj poniższych linków:

- [Utwórz czcionkę zapasową](/slides/pl/java/create-fallback-font)
- [Utwórz kolekcję czcionek zapasowych](/slides/pl/java/create-fallback-fonts-collection)
- [Renderuj prezentację z czcionką zapasową](/slides/pl/java/render-presentation-with-fallback-font)

## **FAQ**

**Czym różnią się czcionki zapasowe od substytucji czcionek?**

Czcionki zapasowe są stosowane znak po znaku lub w zakresie Unicode, gdy podstawowa czcionka nie posiada konkretnych glifów; wypełniają jedynie brakujące znaki. [Substitution](/slides/pl/java/font-substitution/) zastępuje brakującą lub niedostępną czcionkę w całym fragmencie lub części tekstu inną czcionką. Mogą być łączone, ale ich zakres i logika wyboru są różne.

**Czy ustawienia czcionek zapasowych są zapisywane w pliku prezentacji?**

Nie. Konfiguracja czcionek zapasowych istnieje w czasie przetwarzania/renderowania w bibliotece i nie jest serializowana do pliku PPTX. Prezentacja nie przechowuje Twoich reguł czcionek zapasowych.

**Czy czcionki zapasowe wpływają na elementy stworzone przez obiekty PowerPoint (SmartArt, wykresy, WordArt)?**

Tak. Tekst wewnątrz tych obiektów przechodzi przez ten sam potok renderowania, więc te same reguły czcionek zapasowych mają zastosowanie zarówno do nich, jak i do zwykłego tekstu.