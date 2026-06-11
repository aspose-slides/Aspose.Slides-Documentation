---
title: Zarządzanie czcionkami zapasowymi w prezentacjach w JavaScript
linktitle: Czcionka zapasowa
type: docs
weight: 50
url: /pl/nodejs-java/fallback-font/
keywords:
- czcionka zapasowa
- dostępna czcionka
- zamiana glifu
- określenie czcionki
- określenie reguły
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zobacz, jak Aspose.Slides dla Node.js używa czcionek zapasowych, aby utrzymać czytelność tekstu w prezentacjach PowerPoint i OpenDocument, gdy oryginalne czcionki nie są dostępne."
---
## **Wstęp**

Czcionki zapasowe są używane, gdy czcionka określona dla tekstu jest dostępna w systemie, ale nie zawiera wymaganego glifu. W takim przypadku Aspose.Slides może użyć jednej z określonych czcionek zapasowych, aby zastąpić brakujący glif.

## **Czcionka zapasowa**

Aspose.Slides umożliwia tworzenie czcionek zapasowych, dodawanie ich do kolekcji czcionek zapasowych, ustawianie kolekcji czcionek zapasowych dla określonej prezentacji, usuwanie czcionek zapasowych z prezentacji, określanie reguł stosowania czcionek zapasowych i inne.

Aby zapoznać się z tymi funkcjami, użyj poniższych linków:

- [Utwórz czcionkę zapasową](/slides/pl/nodejs-java/create-fallback-font)
- [Utwórz kolekcję czcionek zapasowych](/slides/pl/nodejs-java/create-fallback-fonts-collection)
- [Renderuj prezentację z czcionką zapasową](/slides/pl/nodejs-java/render-presentation-with-fallback-font)

## **FAQ**

**Czym różnią się czcionki zapasowe od zamiany czcionek?**

Czcionka zapasowa jest stosowana dla pojedynczego znaku lub zakresu znaków Unicode, gdy podstawowa czcionka nie posiada określonych glifów; wypełnia jedynie brakujące znaki. [Zamiana](/slides/pl/nodejs-java/font-substitution/) zastępuje brakującą lub niedostępną czcionkę dla całego ciągu lub fragmentu tekstu inną czcionką. Mogą być łączone, ale ich zakres i logika wyboru są różne.

**Czy ustawienia czcionek zapasowych są zapisywane w pliku prezentacji?**

Nie. Konfiguracja czcionek zapasowych istnieje w czasie przetwarzania/renderowania w bibliotece i nie jest serializowana do pliku PPTX. Prezentacja nie przechowuje Twoich reguł czcionek zapasowych.

**Czy czcionki zapasowe wpływają na elementy tworzone przez obiekty PowerPoint (SmartArt, wykresy, WordArt)?**

Tak. Tekst wewnątrz tych obiektów przechodzi przez ten sam proces renderowania, więc te same reguły czcionek zapasowych mają zastosowanie zarówno do niego, jak i do zwykłego tekstu.