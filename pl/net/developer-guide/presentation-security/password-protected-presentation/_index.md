---
title: Prezentacje zabezpieczone hasłem w .NET
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/net/password-protected-presentation/
keywords:
- prezentacja zabezpieczona hasłem
- hasło otwierające
- szyfrowanie PowerPoint
- odszyfrowywanie PowerPoint
- walidacja hasła prezentacji
- sprawdzenie hasła prezentacji
- otwieranie zaszyfrowanej prezentacji
- usunięcie szyfrowania
- PowerPoint
- PPT
- PPTX
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Szyfruj, wykrywaj, waliduj, otwieraj i odszyfrowuj prezentacje PowerPoint PPT i PPTX zabezpieczone hasłem w C# przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Hasło otwierające szyfruje prezentację. Prawidłowe hasło jest wymagane do załadowania i wyświetlenia zawartości prezentacji, więc ta ochrona zapewnia poufność.

Hasło otwierające różni się od hasła ochrony przed zapisem. Ochrona przed zapisem ogranicza modyfikację, ale nie szyfruje zawartości ani nie uniemożliwia załadowania prezentacji. Aby zarządzać hasłami służącymi do modyfikacji prezentacji, zobacz [Write-Protect Presentations](/slides/pl/net/write-protected-presentation/).

Poniższe przepływy pracy dotyczą zarówno prezentacji PPT, jak i PPTX. Przykłady używają obu formatów, gdy istotne jest ich zachowanie oparte na pliku i strumieniu.

## **Zaszyfruj prezentację hasłem otwierającym**

Użyj [IProtectionManager.Encrypt](https://reference.aspose.com/slides/pl/net/aspose.slides/iprotectionmanager/encrypt/), aby przypisać hasło otwierające. Następnie użyj [IPresentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/save/), aby zapisać zaszyfrowaną prezentację.

Poniższy przykład szyfruje prezentację PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Załaduj zaszyfrowaną prezentację**

Ustaw [LoadOptions.Password](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/password/) na hasło otwierające i przekaż opcje do [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) podczas ładowania pliku. Ładowanie nie powiedzie się, gdy wymagane jest hasło otwierające, a podane hasło jest brakujące lub nieprawidłowe.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Pracuj z odszyfrowaną prezentacją.
```

## **Usuń szyfrowanie z prezentacji**

Załaduj prezentację z jej hasłem otwierającym, wywołaj [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/pl/net/aspose.slides/iprotectionmanager/removeencryption/) i zapisz wynik. Zapisana prezentacja może być następnie załadowana bez hasła.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Sprawdź hasło otwierające przed załadowaniem**

Użyj [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationfactory/getpresentationinfo/), aby uzyskać [IPresentationInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/) bez tworzenia pełnej instancji prezentacji. Sprawdź [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/ispasswordprotected/) przed żądaniem lub weryfikacją hasła. Gdy ochrona jest obecna, zweryfikuj podaną wartość przy pomocy [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/checkpassword/).

### **Przepływ pracy z ścieżką do pliku**

Poniższy przykład weryfikuje hasło otwierające dla pliku PPTX, przekazuje zweryfikowaną wartość do [LoadOptions.Password](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/password/), a następnie ładuje pełną prezentację:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Przepływ pracy ze strumieniem**

Przeciążenie strumieniowe [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationfactory/getpresentationinfo/) zapewnia ten sam przepływ pracy. Zresetuj pozycję strumienia umożliwiającego przeszukiwanie przed załadowaniem pełnej prezentacji z tego strumienia.

Poniższy przykład używa pliku PPT:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Wartości zwracane przez CheckPassword**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/checkpassword/) zwraca `true` tylko wtedy, gdy prezentacja ma hasło otwierające i podane hasło jest prawidłowe. Zwraca `false` w każdym z poniższych przypadków:

- Hasło jest nieprawidłowe.
- Prezentacja nie ma hasła otwierającego.
- Podane hasło jest `null` lub puste.

Zachowanie jest takie samo dla prezentacji PPT i PPTX.

## **Sprawdź, czy załadowana prezentacja jest zaszyfrowana**

Po załadowaniu prezentacji przy użyciu prawidłowego hasła sprawdź [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/pl/net/aspose.slides/iprotectionmanager/isencrypted/), aby potwierdzić, że pierwotna prezentacja była zaszyfrowana. Aby wykryć ochronę hasłem otwierającym przed załadowaniem, użyj `IPresentationInfo.IsPasswordProtected` jak pokazano powyżej.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Zalecenia bezpieczeństwa**

{{% alert color="warning" title="Bezpieczeństwo" %}}
Nie zapisuj haseł otwierających w logach ani nie dołączaj ich do komunikatów diagnostycznych. Unikaj niepotrzebnych powtarzalnych prób weryfikacji, przechowuj hasła w pamięci tylko tak długo, jak jest to potrzebne, oraz ponownie użyj wyniku udanej weryfikacji przy natychmiastowym ładowaniu prezentacji.
{{% /alert %}}

## **Zabezpiecz prezentację hasłem online**

1. Otwórz aplikację [Aspose.Slides Lock](https://products.aspose.app/slides/pl/lock).
2. Wybierz lub prześlij prezentację.
3. Wprowadź hasło ochrony podglądu.
4. Opcjonalnie wprowadź osobne hasło ochrony edycji.
5. Zastosuj ochronę i pobierz wynikowy plik.

{{% alert color="info" title="Zobacz również" %}}
- [Zabezpiecz prezentacje przed zapisem](/slides/pl/net/write-protected-presentation/)
- [Podpis cyfrowy w PowerPoint](/slides/pl/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między hasłem otwierającym a hasłem ochrony przed zapisem?**

Hasło otwierające szyfruje prezentację i jest wymagane do załadowania jej zawartości. Hasło ochrony przed zapisem ogranicza modyfikację bez szyfrowania zawartości.

**Czy mogę zweryfikować hasło otwierające bez ładowania wszystkich slajdów?**

Tak. Pobierz informacje o prezentacji, sprawdź, czy istnieje ochrona hasłem otwierającym, i zweryfikuj hasło przed utworzeniem pełnej instancji prezentacji.

**Czy przepływy weryfikacji hasła obsługują zarówno PPT, jak i PPTX?**

Tak. Wykrywanie i weryfikacja hasła oparte na ścieżce do pliku i strumieniu zachowują się tak samo dla prezentacji PPT i PPTX.