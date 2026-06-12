---
title: Instalace Aspose.Slides pro SharePoint
type: docs
weight: 10
url: /cs/sharepoint/installing-aspose-slides-for-sharepoint/
---
{{% alert color="primary" %}} 

Aspose.Slides for SharePoint se stahuje jako archiv Aspose.Slides.SharePoint.zip. Archiv obsahuje: 

- **Aspose.Slides.SharePoint.wsp**: soubor řešení SharePoint. Aspose.Slides for SharePoint je zabalen jako řešení SharePoint pro usnadnění aktivace a deaktivace v celé farmě serverů.
- **Aspose_LicenseAgreement.rtf**: Licenční smlouva pro koncového uživatele.
- **Setup.exe**: instalační program.
- **Setup.exe.config**: konfigurační soubor instalace.

{{% /alert %}} 
## **Instalační proces**
Před spuštěním instalace program setup provádí kontrolu, že:

- je nainstalován WSS 3.0 nebo MOSS 2007.
- uživatel má oprávnění instalovat řešení SharePoint.
- databáze SharePoint je online.
- služba WSS Administration je spuštěna.
- služba WSS Timer je spuštěna.

Služby WSS Administration a Timer jsou potřebné, protože některé akce instalace závisí na časovém úkolu, který se šíří na všechny servery v farmě.

### **Spuštění instalace**
Pro instalaci Aspose.Slides for SharePoint: 

1. Rozbalte archiv Aspose.Slides.SharePoint na místní disk na serveru MOSS 7.0 nebo WSS 3.0.
2. Spusťte setup.exe a postupujte podle pokynů na obrazovce.
   Program setup provádí následující kroky:
   1. Kontroluje předpoklady instalace. Instalace nebude pokračovat, pokud některá kontrola selže. 

      **Spouštění systémové kontroly** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_1.png)




3. Zobrazí Licenční smlouvu pro koncového uživatele. Pro pokračování musíte smlouvu přijmout. 

   **EULA** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_2.png)




4. Zobrazí výběr cíle nasazení. Vybere webové aplikace a kolekce webů, pro které má být funkce aktivována. 

   **Výběr cílů nasazení** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_3.png)




5. Nasadí funkci do farmy serverů. 

   **Ukazatel průběhu instalace** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_4.png)




6. Aktivuje Aspose.Slides pro vybrané kolekce webů a nakonfiguruje jejich nadřazené webové aplikace.
7. Zobrazí seznam webových aplikací a kolekcí webů, pro které byla funkce nasazena a aktivována. 

   **Úspěšná instalace** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_5.png)