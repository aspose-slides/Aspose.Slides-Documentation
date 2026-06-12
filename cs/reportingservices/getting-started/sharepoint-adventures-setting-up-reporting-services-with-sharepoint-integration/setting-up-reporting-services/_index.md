---
title: Nastavení Reporting Services
type: docs
weight: 30
url: /cs/reportingservices/setting-up-reporting-services/
---
{{% alert color="primary" %}} 

Naším prvním zastavením na serveru RS je Správce konfigurace Reporting Services. 

{{% /alert %}} 
## **Service Account**
Ujistěte se, že rozumíte, jaký účet služby používáte pro Reporting Services. Pokud narazíme na problémy, může to být souvislé s použitým účtem služby. Výchozí je Network Service. Kdykoli nasazuji nové verze, vždy používám doménové účty, protože právě tam nejčastěji vznikají problémy. Pro tuto konfiguraci na mém serveru jsem použil doménový účet nazvaný **RSService**. 
## **Web Service URL**
Budeme muset nakonfigurovat URL webové služby. Jedná se o virtuální adresář **ReportServer** (vdir), který hostuje webové služby používané Reporting Services a se kterým bude komunikovat SharePoint. Pokud nechcete přizpůsobovat vlastnosti virtuálního adresáře (např. SSL, porty, host headery atd.), stačí zde kliknout na Použít a můžete pokračovat. 

![todo:image_alt_text](setting-up-reporting-services_1.png)

![todo:image_alt_text](setting-up-reporting-services_2.png)


**Obrázek 3**: Nastavení URL webové služby 

Po dokončení byste měli vidět následující obrázek. 

![todo:image_alt_text](setting-up-reporting-services_3.png)

**Obrázek 4**: Úspěšné nastavení URL webové služby 
## **Database**
Musíme vytvořit databázi katalogu Reporting Services. Ta může být umístěna na jakémkoli SQL 2008 nebo SQL 2008 R2 databázovém engine. SQL11 by také fungoval, ale je stále v BETA verzi. Tato akce vytvoří standardně dvě databáze, **ReportServer** a **ReportServerTempDB**. 
Dalším důležitým krokem je zvolit typ databáze **SharePoint Integrated**. Po provedení tohoto výběru jej nelze změnit. Viz obrázky 5, 6 a 7. 

![todo:image_alt_text](setting-up-reporting-services_4.png)

**Obrázek 5**: Vytváření databáze Report Server 

![todo:image_alt_text](setting-up-reporting-services_5.png)

**Obrázek 6**: Nastavování databázového serveru a typu ověřování 

![todo:image_alt_text](setting-up-reporting-services_6.png)

**Obrázek 7**: Nastavování názvu databáze a režimu 

Pro přihlašovací údaje jde o to, jakým způsobem bude Report Server komunikovat se SQL Serverem. Vybraný účet získá určitá oprávnění v databázi katalogu i v několika systémových databázích prostřednictvím role RSExecRole. MSDB je jednou z těchto databází pro použití předplatného, protože využíváme SQL Agent. 

![todo:image_alt_text](setting-up-reporting-services_7.png)

**Obrázek 8**: Nastavování přihlašovacích údajů databáze Report Server 

Po dokončení by mělo vypadat jako na následujícím obrázku. 

![todo:image_alt_text](setting-up-reporting-services_8.png)


**Obrázek 9**: Pokrok k dokončení nastavení databáze Report Server 
## **Report Manager URL**
Můžeme přeskočit URL Report Manageru, protože se v režimu SharePoint Integrated nepoužívá. SharePoint je naším frontendem. Report Manager nefunguje. 
## **Encryption Keys**
Zálohujte své šifrovací klíče a ujistěte se, že víte, kde jsou uloženy. Pokud se dostanete do situace, kdy potřebujete migrovat databázi nebo ji obnovit, budete je potřebovat. 

![todo:image_alt_text](setting-up-reporting-services_9.png)

To je vše pro Správce konfigurace Reporting Services. Pokud přejdete na URL na kartě Web Service URL, mělo by se zobrazit něco podobného následujícímu obrázku. 

![todo:image_alt_text](setting-up-reporting-services_10.png)

**Obrázek 12**: Přístup k Report Serveru po instalaci 

Co se stalo? SharePoint je nainstalován na mém WFE a dokončil jsem nastavování Reporting Services. V tomto příkladu jsou Reporting Services a SharePoint na různých strojích. Kdyby byly na stejném stroji, tato chyba by se neobjevila. Technicky musíme nainstalovat SharePoint na RS Box. To znamená, že bude také povolen IIS.