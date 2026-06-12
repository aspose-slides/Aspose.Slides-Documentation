---
title: Installatievereisten
type: docs
weight: 20
url: /nl/reportingservices/installation-prerequisites/
---
{{% alert color="primary" %}} 

Volgende vereisten moeten vervuld worden voordat we doorgaan met de installatie. 

{{% /alert %}} 
## **Reporting Services Add-In for SharePoint**
De **Reporting Services Add-In for SharePoint** is een van de belangrijkste componenten om de integratie goed te laten werken. De add‑in moet geïnstalleerd worden op elk van de **Web Front Ends (WFE)** die zich in uw SharePoint‑farm bevindt, samen met de Central Admin‑server. Een van de nieuwe wijzigingen met SQL 2008 R2 & SharePoint 2010 is dat de 2008 R2‑add‑in nu een pre‑req is voor de SharePoint‑installatie. Dit betekent dat de RS‑add‑in wordt geïnstalleerd wanneer u SharePoint installeert. Dit wordt hieronder in de afbeelding getoond en gemarkeerd. Dit voorkomt eigenlijk veel van de problemen die we zagen met SP 2007 en RS 2008 bij het installeren van de add‑in. 

![todo:image_alt_text](installation-prerequisites_1.png)


**Figuur 1**: Reporting Services Add-In for SharePoint 
## **SharePoint Authentication**
Voordat we de RS‑integratieonderdelen behandelen, is één belangrijk punt waarvoor moet worden gezorgd hoe u uw **Site** in de SharePoint‑farm instelt. Meer specifiek hoe u de authenticatie voor de site configureert; of deze **Classic** of **Claims** zal zijn. Deze keuze is in het begin belangrijk. Ik geloof niet dat u deze optie later kunt wijzigen. Als u het wel kunt wijzigen, zal het geen eenvoudig proces zijn. 

{{% alert color="primary" %}} 

Reporting Services 2008 R2 is NIET Claims‑aware 

{{% /alert %}} 

Ook al kiest u ervoor dat uw SharePoint‑site **Claims** gebruikt, Reporting Services zelf is niet Claims‑aware. Dit beïnvloedt hoe authenticatie werkt met Reporting Services. Wat is dus het verschil vanuit het perspectief van Reporting Services? Het komt neer op de vraag of u gebruikersreferenties wilt doorsturen naar de gegevensbron. 

**Classic** – Kan Kerberos gebruiken en de gebruikersreferenties doorsturen naar uw back‑end gegevensbron (hiervoor moet Kerberos worden gebruikt).  

**Claims** – Er wordt een Claims‑token gebruikt en geen Windows‑token. RS zal in dit scenario altijd Trusted Authentication gebruiken en heeft alleen toegang tot het SPUser‑token. U moet uw referenties opslaan in de gegevensbron.  

Voor nu willen we ons alleen richten op de configuratie van RS. Op dit moment is SharePoint geïnstalleerd op de SharePoint‑box en ingesteld met een **Classic Auth Site** op **poort 80**. Bovendien heb ik op de RS‑server **zojuist Reporting Services geïnstalleerd** en dat is alles.