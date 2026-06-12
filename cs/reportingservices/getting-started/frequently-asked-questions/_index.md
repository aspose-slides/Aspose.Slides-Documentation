---
title: Často kladené otázky
type: docs
weight: 110
url: /cs/reportingservices/frequently-asked-questions/
---
{{% alert color="primary" %}} 

Tato stránka shromažďuje řadu často kladených otázek o:

- [Podporované formáty souborů](#Supported-File-Formats).
- [Podpora pro služby Power BI Reporting](#Support-for-Power-BI-Reporting-services).
- [Instalace](#Installation).
- [Konfigurace exportu](#Export-Configuration).

{{% /alert %}} 
### **Podporované formáty souborů**
#### **Q: Do jakých formátů můžete exportovat zprávy pomocí Aspose.Slides for Reporting Services?**
**A**: Aspose.Slides for Reporting Services umožňuje exportovat jakoukoli zprávu ve formátu PPT, PPS, PPTX, PPSX, XPS nebo RPL.
### **Podpora pro služby Power BI Reporting**
#### **Q: Podporuje Aspose.Slides for Reporting Services Power BI?**
**A**: Ano. Aspose.Slides for Reporting Services podporuje export stránkovaných zpráv (RDL) v Power BI.
### **Instalace**
#### **Q: Instalační program se nespouští. Ruční instalace nedosahuje požadovaného výsledku.**
**A** : Ujistěte se, že je ve vašem systému nainstalováno .NET Framework 3.5.
#### **Q: Po instalaci Aspose.Slides for Reporting Services chybí možnosti exportu.**
**A**: Pokud v souboru rssrvpolicy.config nefunguje některá CodeGroup správně, může parser konfiguračního souboru přeskočit poslední sekce skupiny. Proto přesuňte všechny CodeGroupy související s Aspose.Slides for Reporting Services na začátek bloku, který obsahuje CodeGroupy Aspose.Slides for Reporting Services.
#### **Q: Could not load file or assembly Aspose.Slides.ReportingServices (Execution permission cannot be acquired \ Exception from HRESULT: 0x80131418).**
**A**: Kód chyby (0x80131418) naznačuje, že modul dll nemá dostatečná oprávnění. To může být způsobeno bezpečnostní funkcí, která zablokovala plný přístup k souboru .dll, pokud byl získán z jiného počítače. Toto lze opravit otevřením okna vlastností souboru dll a kliknutím na tlačítko „Unblock“ v panelu „Security“.
#### **Q: Cannot find license 'Aspose.Slides.Reporting.Services.lic'.**
**A**: Licenční soubor musí být umístěn vedle souboru dll nebo v adresáři Program Files(x86)\Aspose\Slides\.
### **Konfigurace exportu**
#### **Q: Jak mohu změnit barvu hypertextových odkazů v exportované zprávě?**
**A**: Každé rozšíření vykreslování Aspose.Slides for Reporting Services v rsreportserver.config má vlastní konfiguraci. Pro změnu barvy hypertextových odkazů nastavte požadovanou hodnotu v sekci <HyperlinkColor>.
#### **Q: V exportovaných prezentacích je text v tabulkách natáhnut vertikálně.**
**A**: Toto je provedeno pro snadnější čtení dokumentu. Pro zobrazení textu v tabulce tak, jak se objevuje v zprávě, nastavte požadované rozšíření Aspose.Slides for Reporting Services na „Normal“ v konfiguračním souboru rsreportserver.config.