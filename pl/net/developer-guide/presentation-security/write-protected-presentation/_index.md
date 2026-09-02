---
title: Ochrona przed zapisem prezentacji w .NET
linktitle: Ochrona przed zapisem
type: docs
weight: 25
url: /pl/net/write-protected-presentation/
keywords:
- ochrona przed zapisem
- ochrona przed zapisem PowerPoint
- hasło do modyfikacji
- ogranicz edytowanie prezentacji
- usuń ochronę przed zapisem
- zweryfikuj hasło modyfikacji
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Ustaw, wykrywaj, weryfikuj i usuwaj hasła ochrony przed zapisem w prezentacjach PowerPoint PPT i PPTX przy użyciu Aspose.Slides dla .NET."
---
## **Wprowadzenie**

Hasło ochrony przed zapisem ogranicza modyfikację prezentacji, ale nie szyfruje jej zawartości. Użytkownicy mogą załadować i przeglądać prezentację zabezpieczoną przed zapisem bez podania hasła. W zależności od aplikacji mogą również edytować zawartość i zapisać ją pod inną nazwą, więc ochrona przed zapisem nie powinna być traktowana jako mechanizm poufności.

Hasło otwierające spełnia inną funkcję: szyfruje prezentację i jest wymagane do załadowania jej zawartości. Aby zaszyfrować prezentację lub zweryfikować hasło otwierające, zobacz [Password-Protect Presentations](/slides/pl/net/password-protected-presentation/).

Procedury opisane w tym artykule dotyczą zarówno prezentacji PPT, jak i PPTX. Przykłady używają plików PPTX; przy zapisywaniu do formatu PPT użyj rozszerzenia `.ppt` oraz odpowiedniego formatu zapisu PPT.

## **Ustaw ochronę przed zapisem w prezentacji**

Użyj [IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/pl/net/aspose.slides/iprotectionmanager/setwriteprotection/), aby przypisać hasło służące do modyfikacji prezentacji. Zapisanie prezentacji utrwala ustawienie ochrony.

Poniższy przykład ustawia ochronę przed zapisem w prezentacji PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **Załaduj prezentację zabezpieczoną przed zapisem**

Ponieważ ochrona przed zapisem nie szyfruje zawartości prezentacji, do jej załadowania nie jest wymagane żadne hasło. Hasło jest istotne tylko przy weryfikacji uprawnienia do modyfikacji chronionej prezentacji.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Nie przekazuj hasła ochrony przed zapisem do [LoadOptions.Password](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/password/). Właściwość ta przyjmuje hasło otwierające dla zaszyfrowanej zawartości. Jeśli prezentacja ma oba typy ochrony, podaj hasło otwierające, aby ją załadować, a hasło ochrony przed zapisem obsłuż osobno.

## **Usuń ochronę przed zapisem z prezentacji**

Użyj [IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/pl/net/aspose.slides/iprotectionmanager/removewriteprotection/), aby usunąć ograniczenie modyfikacji, a następnie zapisz prezentację.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **Sprawdź, czy prezentacja jest zabezpieczona przed zapisem**

Aby sprawdzić plik bez tworzenia pełnego obiektu [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/), wywołaj [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationfactory/getpresentationinfo/) i sprawdź [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/iswriteprotected/). Właściwość używa [NullableBool](https://reference.aspose.com/slides/pl/net/aspose.slides/nullablebool/) i zwraca `NullableBool.True`, gdy wykryto ochronę przed zapisem.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

Przeciążenie strumieniowe [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationfactory/getpresentationinfo/) dostarcza te same informacje dla prezentacji przekazanej jako strumień.

## **Sprawdź poprawność hasła ochrony przed zapisem**

Użyj [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/checkwriteprotection/), aby zweryfikować hasło modyfikacji bez ładowania pełnej prezentacji. Najpierw sprawdź [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/iswriteprotected/), aby aplikacja żądała lub weryfikowała hasło tylko wtedy, gdy istnieje ochrona przed zapisem.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/checkwriteprotection/) weryfikuje wyłącznie hasło ochrony przed zapisem. Nie weryfikuje hasła otwierającego ani nie określa, czy zaszyfrowana zawartość może zostać załadowana. Natomiast [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/checkpassword/) weryfikuje jedynie hasło otwierające. Jeśli pełna prezentacja została już załadowana, [IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/pl/net/aspose.slides/iprotectionmanager/checkwriteprotection/) zapewnia równoważną kontrolę ochrony przed zapisem poprzez manager ochrony.

W aplikacjach produkcyjnych nie loguj haseł ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych powtarzających się prób weryfikacji i przechowuj hasła w pamięci tylko tak długo, jak jest to konieczne.

{{% alert color="info" title="Zobacz także" %}}
- [Prezentacje zabezpieczone hasłem](/slides/pl/net/password-protected-presentation/)
- [Prezentacje tylko do odczytu](/slides/pl/net/read-only-presentation/)
- [Podpis cyfrowy w PowerPoint](/slides/pl/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Czy ochrona przed zapisem szyfruje prezentację?**

Nie. Ogranicza modyfikację, ale pozostawia zawartość prezentacji dostępną do ładowania i przeglądania.

**Czy hasło ochrony przed zapisem jest wymagane do otwarcia prezentacji?**

Nie. Tylko hasło otwierające jest wymagane do załadowania zaszyfrowanej zawartości prezentacji.

**Czy prezentacja może mieć jednocześnie hasło otwierające i hasło ochrony przed zapisem?**

Tak. Podaj hasło otwierające w opcjach ładowania, aby otworzyć zaszyfrowaną prezentację, i osobno zweryfikuj hasło ochrony przed zapisem, gdy wymagane jest uprawnienie do modyfikacji.