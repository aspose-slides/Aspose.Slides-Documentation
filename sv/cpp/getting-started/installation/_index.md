---
title: Installation
type: docs
weight: 70
url: /sv/cpp/installation/
keywords:
- installera Aspose.Slides
- ladda ner Aspose.Slides
- använd Aspose.Slides
- Aspose.Slides installation
- Windows
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du snabbt installerar Aspose.Slides för C++. Steg-för-steg-guide, systemkrav och kodexempel — börja arbeta med PowerPoint-presentationer idag!"
---
## **Översikt**

Den här artikeln förklarar hur du installerar Aspose.Slides på Windows. Den fokuserar på NuGet‑baserad installation och visar hur du lägger till biblioteket i ett Visual Studio‑projekt antingen via NuGet Package Manager eller Package Manager Console på Windows. Den beskriver också hur du uppdaterar paketet och installerar förhandsutgåvor när det behövs.

## **Windows**
NuGet erbjuder den enklaste vägen för att ladda ner och installera Aspose API:er för C++ på PC:n. 

### **Alternativ ett: Installera eller uppdatera Aspose.Slides för C++ från NuGet Package Manager**

1. Öppna Microsoft Visual Studio. 
2. Skapa en enkel konsolapplikation. Eller så kan du öppna ditt föredragna projekt. 
3. Gå via **Tools** > **NuGet package manager**.
4. Under **Browse**, skriv *Aspose.Slides.Cpp* i textfältet. 

![todo:image_alt_text](installation_1.png)

3. Klicka på den version du behöver **Aspose.Slides.Cpp** och klicka sedan på **Install**. 
   * Om du vill uppdatera Aspose.Slides—vilket betyder att du redan har det installerat—klicka på **Update** istället. 

Det valda API:et laddas ner och refereras i ditt projekt.

### **Alternativ 2: Installera eller uppdatera Aspose.Slides via Package Manager Console**

För att referera till [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.Cpp/) med hjälp av package manager console, gör så här:

1. Öppna din lösning/projekt i Visual Studio.

1. Gå via **Tools** > **NuGet Package Manager** > **Package Manager Console**. 

Package Manager Console öppnas. 

![todo:image_alt_text](installation_2.png)

4. Skriv detta kommando: `Install-Package Aspose.Slides.Cpp` 
> Om du vill installera x86‑versionen, använd paketet Aspose.Slides.Cpp.x86: `Install-Package Aspose.Slides.Cpp.x86`

5. Tryck på Enter. 

Den senaste fullständiga utgåvan installeras i din applikation. 

* Alternativt kan du lägga till suffixet `-prerelease` i kommandot för att ange att den senaste utgåvan (inklusive hotfixar) också ska installeras som helhet.

![todo:image_alt_text](installation_3.png)

När nedladdningen är klar bör du se några bekräftelsemeddelanden.  

![todo:image_alt_text](installation_4.png)

Om du inte är bekant med [Aspose EULA](https://about.aspose.com/legal/eula) kanske du vill läsa licensen som refereras i URL:en. 

I Package Manager Console kan du köra kommandot `Update-Package Aspose.Slides.Cpp` för att kontrollera uppdateringar av Aspose.Slides‑paketet. Uppdateringar (om de finns) installeras automatiskt. Du kan också använda suffixet `-prerelease` för att uppdatera den senaste utgåvan.

### **Använda Include- och lib‑mappar**
1. [Download](https://downloads.aspose.com/slides/sv/cpp) den senaste versionen av Aspose.Slides för C++.
1. Packa upp mappen till produktionsmiljön.
1. För att använda Aspose.Slides för C++, referera Include- och lib‑mapparna i ditt projekt

## **FAQ**

**Finns det en gratis version eller begränsning i provperioden?**

Ja, som standard kör Aspose.Slides i evalueringsläge, vilket lägger till vattenstämplar och kan ha andra begränsningar. För att ta bort begränsningarna måste du tillämpa en giltig [license](/slides/sv/cpp/licensing/).