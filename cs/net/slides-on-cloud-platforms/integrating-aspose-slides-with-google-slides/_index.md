---
title: Integrace Aspose.Slides s Google Slides
linktitle: Google Slides
type: docs
weight: 50
url: /cs/net/integrating-aspose-slides-with-google-slides/
keywords:
- cloudové platformy
- cloudová integrace
- Google Slides
- Google Drive
- Google API
- Google účet služby
- SaaS integrace
- OAuth 2.0
- PPT na PDF
- automatizace PowerPointu
- zpracování prezentací
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Propojte Aspose.Slides s Google Slides pro import, synchronizaci a konverzi prezentací, automatizaci pracovních toků a udržení PowerPointu a OpenDocumentu v jednom postupu."
---
## **Úvod**

Aspose.Slides nyní poskytuje integraci s Google Slides a Google Drive prostřednictvím svého [SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations). Tato integrace umožňuje .NET aplikacím konvertovat, upravovat, stahovat a nahrávat prezentace Google Slides.

## **Co je Google Slides?**
[Google Slides](https://workspace.google.com/products/slides/cs/) je zdarma dostupný webový prezentační software vyvinutý společností Google. Umožňuje uživatelům vytvářet, upravovat a sdílet prezentace online, podobně jako Microsoft PowerPoint. Podporuje spolupráci v reálném čase, cloudové úložiště a funguje na jakémkoli zařízení s přístupem k internetu.

## **Google API**
Než začnete pracovat s vaší prezentací Google Slides přes Aspose.Slides, musíte vytvořit projekt Google API a založit [Google Cloud projekt](https://developers.google.com/workspace/guides/create-project), poté povolit požadované API.

Pak musíte zvolit způsob, jakým budete přistupovat k Google API – [Aspose.Slides Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) podporuje dva způsoby přístupu k Google API: 
- `Google Service Account`
- `OAuth 2.0` s interakcí uživatele přes prohlížeč.

### **Google Service Account**
Účet služby je speciální Google účet používaný aplikacemi nebo servery k programatickému přístupu k Google API bez zásahu uživatele. Často se používá pro backendové systémy nebo automatizované úlohy. Účty služby jsou autentizovány pomocí JSON souboru s klíčem a mají vlastní e‑mailovou adresu. Mohou být přiřazeny konkrétní oprávnění prostřednictvím [Google Cloud IAM](https://cloud.google.com/iam/docs/overview) a často se používají s API jako Google Drive, Sheets nebo BigQuery pro zabezpečený, automatizovaný přístup ke zdrojům.

### **OAuth 2.0**
Dalším běžným způsobem přístupu k Google API je OAuth 2.0 s interakcí uživatele přes prohlížeč. V tomto toku je uživatel přesměrován na přihlašovací stránku Google, kde udělí aplikaci oprávnění. Po schválení aplikace získá autorizační kód, který vymění za přístupový token a obnovovací token.

Přístupový token umožňuje dočasný přístup k Google API, zatímco obnovovací token lze uložit a použít k získání nových přístupových tokenů bez nutnosti opětovného přihlášení uživatele. To znamená, že interakce s prohlížečem je vyžadována jen jednou, následný přístup k API je plně automatizovaný. Tato metoda se typicky používá pro aplikace, které potřebují přístup k uživatelským datům (např. Gmail, Calendar nebo Drive) s uživatelovým souhlasem.

## **Pojďme kódovat**
Nejprve přidejte balíček [Aspose.Slides SaaS Integration NuGet](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) do svého projektu:

```
dotnet add package Aspose.Slides.SaaSIntegrations
```

### **Příklad 1**
V následujícím příkladu stáhneme prezentaci Google Slides z Google Drive a uložíme ji na lokální disk jako PDF soubor. K autorizaci použijeme Google Service Account, předpokládáme, že JSON soubor s pověřeními byl již stažen.

```csharp
// Vytvořte externě spravovaný HttpClient
HttpClient httpClient = new HttpClient();

// Vytvořte poskytovatele autorizace pomocí JSON souboru účtu služby
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// Inicializujte službu integrace Google Slides s poskytovatelem autorizace
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Načtěte prezentaci z Google Drive podle jejího ID souboru do instance Aspose.Slides IPresentation
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// Upravte prezentaci podle potřeby (např. odstraňte druhý snímek)
pres.Slides.RemoveAt(1);

// Uložte prezentaci lokálně jako PDF soubor
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```

Pro pohodlí poskytuje Aspose.Slides SaaS Integration metodu pro výpis všech souborů dostupných uživateli. Vrácená data obsahují název souboru, MIME typ a ID souboru.

```csharp
// Získejte seznam souborů dostupných poskytnutému účtu služby
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```

Dalším způsobem, jak získat ID souboru, je otevřít prezentaci ve webové aplikaci Google Slides a najít jej v adrese URL.

Například v následující URL:

```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```

ID souboru je:

```
1A2B3C4D5E6F7G8H9I0J
```

## **Příklad 2**
V dalším příkladu vytvoříme prezentaci PowerPoint od nuly a nahrajeme ji na Google Drive ve formátu Google Slides. K autorizaci použijeme OAuth 2.0.

```csharp
// Vytvořte externě spravovaný HttpClient
HttpClient httpClient = new HttpClient();

// Vytvořte poskytovatele autorizace pomocí OAuth s ID klienta a tajným klíčem klienta
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// Inicializujte službu integrace Google Slides s poskytovatelem autorizace
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Vytvořte ukázkovou prezentaci
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // Uložte prezentaci do kořenové složky Google Drive ve formátu Google Slides
    // Můžete také zvolit jakýkoli jiný exportní formát podporovaný knihovnou Aspose.Slides
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```

Pokud ve své aplikaci používáte tento typ autorizace, `interakce s prohlížečem je vyžadována`. Budete muset vybrat svůj účet a potvrdit, že povolujete aplikaci přístup k API Google Drive. To je vše – tato operace je potřebná pouze při prvním spuštění.

### **Příklad 3**
V následujícím příkladu použijeme předem získaný přístupový token. `GoogleAccessTokenAuthProvider` je implementace rozhraní `IGoogleAuthorizationProvider`, která používá existující OAuth 2.0 přístupový token k autorizaci požadavků na Google API. Na rozdíl od poskytovatelů, kteří spouštějí nebo spravují OAuth tok, tato třída spoléhá na to, že volající předá platný přístupový token.

Tento poskytovatel je užitečný v systémech, kde je přístupový token získáván externě – typicky frontendovou aplikací nebo jinou službou – a předává se backendu. Je obzvláště vhodný pro distribuované prostředí, kde správa obnovovacích tokenů na serveru zavádí složitost nebo riziko neplatnosti tokenu při souběžných pokusech o obnovu.

Tento příklad ukazuje, jak nahradit soubor a aktualizovat jeho název na Google Drive při zachování ID souboru.

```csharp
// Vytvořte HTTP klienta pro provádění požadavků
using HttpClient httpClient = new HttpClient();

// Nastavte autentizaci Google Drive pomocí přístupového tokenu
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// Inicializujte integraci s Google Slides/Drive pomocí autentizace a HTTP klienta
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// Vytvořte ukázkovou prezentaci pomocí Aspose.Slides
using (var presentation = new Presentation())
{
    // Přidejte obdélníkový tvar na první snímek a nastavte jeho text
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // Definujte možnosti uložení PDF s konkrétní kvalitou a nastavením souladu
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // Uložte (nahraďte) existující soubor na Google Drive pomocí ID souboru, aktualizujte jeho název a exportujte jako PDF
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // ID existujícího souboru na Google Drive
        GoogleSaveFormatType.Pdf,         // Požadovaný formát pro uložení
        saveOptions,           
        "NewFileName.pdf"                 // Nový název, který má být souboru přiřazen
    );
}
```

## **Shrnutí**
Aspose.Slides nyní podporuje další formát souboru pro správu, což zjednodušuje automatizaci cloudových pracovních toků pro vytváření, sdílení a úpravu prezentací.

Tento článek popsal základní funkce. Můžete také ukládat soubory do podsložek, nahrazovat existující soubory a exportovat do Google Drive v různých formátech – nejen v prezentacích Google Slides.

Aspose.Slides SaaS Integration bude nadále rozšiřovat podporu pro SaaS platformy pro prezentace, proto sledujte budoucí aktualizace.

## **FAQ**

**Potřebuji účet Google Workspace k použití této integrace?**  
Ne. Můžete použít buď zdarma dostupný Google účet, nebo účet Google Workspace. Požadovaný přístup závisí na oprávněních ve vašem Google Drive a Slides.

**Jakou metodu autentizace si mám vybrat – Service Account nebo OAuth 2.0?**  
Použijte **Service Account** pro backendové nebo automatizované workflow bez interakce uživatele.  
Použijte **OAuth 2.0**, pokud potřebujete přístup k konkrétním souborům Google Slides nebo Drive konkrétního uživatele s jeho souhlasem.

**Mohu pracovat s formáty jinými než Google Slides?**  
Ano. Aspose.Slides umožňuje uložit prezentaci do různých formátů (např. PDF, PPTX, HTML) před nahráním na Google Drive.

**Jak získám ID souboru prezentace Google Slides?**  
Můžete jej získat pomocí metody `GetDriveFileInfosAsync()` nebo zkopírováním z URL prezentace v Google Slides.

**Podporuje integrace nahrazení existujícího souboru na Google Drive?**  
Ano. Použijte metodu `SavePresentationToExistingFileAsync` k aktualizaci souboru při zachování jeho ID.

**Je interakce s prohlížečem vyžadována při každém použití OAuth 2.0?**  
Ne. Interakce s prohlížečem je potřeba jen při první autorizaci. Poté uložené obnovovací tokeny umožňují automatizovaný přístup.