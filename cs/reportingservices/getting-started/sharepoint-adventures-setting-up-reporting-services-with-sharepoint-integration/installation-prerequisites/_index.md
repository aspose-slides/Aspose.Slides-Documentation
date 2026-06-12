---
title: Požadavky na instalaci
type: docs
weight: 20
url: /cs/reportingservices/installation-prerequisites/
---
{{% alert color="primary" %}} 
Před zahájením instalace je nutné splnit následující předpoklady. 
{{% /alert %}} 
## **Reporting Services Add-In pro SharePoint**
**Reporting Services Add-In pro SharePoint** je jednou z klíčových součástí, které zajišťují správnou funkčnost integrace. Add-In musí být nainstalován na jakémkoli **Web Front End (WFE)** ve vaší farmě SharePoint spolu se serverem Central Admin. Jednou z nových změn v SQL 2008 R2 a SharePoint 2010 je, že Add-In pro 2008 R2 je nyní předpokladem pro instalaci SharePointu. To znamená, že RS Add-In bude nasazen, když budete instalovat SharePoint. Je zobrazen a zvýrazněn na obrázku níže. To skutečně eliminuje mnoho problémů, které jsme pozorovali při instalaci Add-Inu v SP 2007 a RS 2008.

![todo:image_alt_text](installation-prerequisites_1.png)

**Obrázek 1**: Reporting Services Add-In pro SharePoint 
## **Autentizace SharePoint**
Než se pustíme do částí integrace RS, je důležité zajistit, jak nastavíte svůj **Site** ve farmě SharePoint. Konkrétně jak nakonfigurujete autentizaci pro Site; zda bude **Classic** nebo **Claims**. Toto rozhodnutí je na začátku důležité. Nevím, že by bylo možné tuto volbu po provedení změnit. Pokud by se dalo, nejednalo by se o jednoduchý proces. 

{{% alert color="primary" %}} 
Reporting Services 2008 R2 není kompatibilní s Claims 
{{% /alert %}} 

I když si vyberete, aby váš SharePoint site používal **Claims**, samotné Reporting Services nejsou Claims‑aware. Ovlivňuje to způsob, jakým funguje autentizace v Reporting Services. Jaký tedy je rozdíl z pohledu Reporting Services? Záleží na tom, zda chcete předávat uživatelské přihlašovací údaje do datového zdroje. 

***Classic*** – lze použít Kerberos a předat uživatelské přihlašovací údaje do backendového datového zdroje (bude potřeba použít Kerberos). 
***Claims*** – používá se token Claims místo tokenu Windows. RS v tomto scénáři vždy použije Trusted Authentication a bude mít přístup jen k tokenu SPUser. Vaše přihlašovací údaje budete muset uložit v datovém zdroji. 

Prozatím se chceme soustředit jen na nastavení RS. V tuto chvíli je SharePoint nainstalován na SharePoint Box a nastaven s **Classic Auth Site** na **portu 80**. Navíc jsem na serveru RS **právě nainstaloval Reporting Services** a to je vše.