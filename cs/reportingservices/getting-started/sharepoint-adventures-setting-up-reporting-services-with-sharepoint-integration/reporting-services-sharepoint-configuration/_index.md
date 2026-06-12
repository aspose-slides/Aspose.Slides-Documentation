---
title: Konfigurace Reporting Services v SharePointu
type: docs
weight: 50
url: /cs/reportingservices/reporting-services-sharepoint-configuration/
---
{{% alert color="primary" %}} 

Nyní, když je SharePoint nainstalován a nakonfigurován na serveru RS a RS je nastaven prostřednictvím Reporting Services Configuration Manageru, můžeme přejít k nastavení v Central Admin. RS 2008 R2 tento proces opravdu zjednodušil. Dříve jsme museli provést tříkrokový proces, aby to fungovalo. Nyní máme jen jeden krok. 

Chceme přejít na webové stránky Central Administrator a poté do sekce General Application Settings. V dolní části uvidíme Reporting Services. 

{{% /alert %}} 

![todo:image_alt_text](reporting-services-sharepoint-configuration_1.png)


**Figure 17**: Konfigurace SharePoint 

{{% alert color="primary" %}} 

Klikněte na **Reporting Services Integration**. 

{{% /alert %}} 
## **Webová adresa služby**
Zadáme URL pro Report Server, kterou jsme našli v Reporting Services Configuration Manageru. 
## **Režim ověřování**
Také vybereme režim ověřování. Následující odkaz na MSDN podrobně popisuje, co tyto režimy jsou. 
[Přehled zabezpečení pro Reporting Services v režimu SharePoint Integrated](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb283324(v=sql.105)) 

Stručně řečeno, pokud váš web používá **Claims Authentication**, vždy budete používat Trusted Authentication bez ohledu na to, co zde vyberete. Pokud chcete předat Windows přihlašovací údaje, zvolíte Windows Authentication. pro Trusted Authentication předáme token SPUser a nebudeme se spoléhat na Windows přihlašovací údaje. 

Trusted Authentication budete také chtít použít, pokud jste nakonfigurovali své weby v Classic Mode pro NTLM a RS je nastaven na NTLM. Pro použití Windows Authentication a předání tohoto pro váš zdroj dat by byl potřeba Kerberos. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_2.png)


**Figure 18**: Nastavení přihlašovacích údajů pro Reporting Services Integration
## **Aktivovat funkci**
Toto vám dává možnost aktivovat Reporting Services na všech kolekcích webů, nebo si můžete vybrat, které chcete aktivovat. V podstatě to znamená, které weby budou moci používat Reporting Services. Po dokončení byste měli vidět následující obrázek. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_3.png)


**Figure 19**: Úspěšná integrace Reporting Services s prostředím SharePoint 

Když se vrátíme k URL Report Serveru uvedenému na Obrázku 14, měli bychom vidět něco podobného následujícímu obrázku. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_4.png)


**Figure 20**: Úspěšné ověření Reporting Services s prostředím SharePoint 

{{% alert color="primary" %}} 

Pokud je váš SharePoint web nakonfigurován pro SSL, neobjeví se v tomto seznamu. Jedná se o známý problém a neznamená to, že je něco špatně. Vaše zprávy by měly stále fungovat. 

{{% /alert %}} 

Nyní jsme připraveni používat Reporting Services ve SharePoint 2010. Stejně jako v předchozí verzi máme funkci (aktivovanou při konfiguraci Reporting Services Integration) v „Site Collection Feature“. Instalace také přidala 3 typy obsahu, které lze přidat na náš web. Na Obrázku 21 vidíme 2 typy obsahu přidané do knihovny dokumentů pro vytvoření vlastního reportu, jak je vidět na Obrázku 21. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_5.png)


**Figure 21**: Report Builder 

„**Reporter Builder**“ je ActiveX, který musíme stáhnout na server, jak vidíme na Obrázku 22. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_6.png)


**Figure 22**: Stažení a instalace Report Builder 

Po dokončení stahování spusťte **Report Builder**. Nyní jsme připraveni navrhnout náš první report, jak vidíme na Obrázku 23. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_7.png)

**Figure 23**: Průvodce vytvořením nového reportu v Report Builder 

Po vytvoření našeho reportu jej můžeme uložit do vytvořené knihovny dokumentů, aby byly reporty v našem SharePoint 2010. 

Druhý typ obsahu se musí použít k vytvoření sdíleného připojení jako datového zdroje a uložit jej do knihovny dokumentů ve SharePointu. Můžeme vytvořit knihovnu dokumentů, přidat tento typ obsahu a poté mít naše připojení k dispozici pro změnu datového zdroje reportů. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_8.png)


**Figure 24**: Úspěšný export reportu na Report Server