---
title: Wymagania wstępne instalacji
type: docs
weight: 20
url: /pl/reportingservices/installation-prerequisites/
---
{{% alert color="primary" %}} 

Następujące warunki wstępne muszą zostać spełnione, zanim przejdziemy do instalacji. 

{{% /alert %}} 
## **Reporting Services Add-In for SharePoint**
**Reporting Services Add-In for SharePoint** jest jednym z kluczowych elementów zapewniających prawidłowe działanie integracji. Dodatek musi zostać zainstalowany na dowolnym **Web Front End (WFE)** w Twojej farmie SharePoint, wraz z serwerem Central Admin. Jedną z nowych zmian w SQL 2008 R2 i SharePoint 2010 jest to, że dodatek 2008 R2 jest teraz wymagany wstępnie przy instalacji SharePoint. Oznacza to, że dodatek RS zostanie zainstalowany podczas instalacji SharePoint. Zostało to pokazane i wyróżnione na rysunku poniżej. W praktyce uniknia to wiele problemów, które napotkaliśmy przy instalacji dodatku w SP 2007 i RS 2008. 

![todo:image_alt_text](installation-prerequisites_1.png)


**Rysunek 1**: Reporting Services Add-In for SharePoint 
## **Uwierzytelnianie SharePoint**
Zanim przejdziesz do elementów integracji RS, ważne jest, aby zadbać o to, jak skonfigurujesz swoją **witrynę** w farmie SharePoint. Konkretniej, jak skonfigurujesz uwierzytelnianie dla witryny; czy będzie to **Classic** czy **Claims**. Ten wybór jest ważny na początku. Nie sądzę, aby dało się zmienić tę opcję po jej ustawieniu. Jeśli można ją zmienić, nie będzie to prosty proces. 

{{% alert color="primary" %}} 

Reporting Services 2008 R2 nie obsługuje Claims 

{{% /alert %}} 

Nawet jeśli wybierzesz dla swojej witryny SharePoint użycie **Claims**, sam Reporting Services nie obsługuje Claims. Ma to wpływ na sposób działania uwierzytelniania w Reporting Services. Więc jaka jest różnica z perspektywy Reporting Services? Chodzi o to, czy chcesz przekazywać poświadczenia użytkownika do źródła danych. 

***Classic*** - Może używać Kerberos i przekazywać poświadczenia użytkownika do zaplecza źródła danych (będzie wymagało użycia Kerberos). 

***Claims*** - Używany jest token Claims, a nie token Windows. RS zawsze użyje Trusted Authentication w tym scenariuszu i będzie miał dostęp tylko do tokenu SPUser. Będziesz musiał przechowywać poświadczenia w swoim źródle danych. 

Na razie chcemy skoncentrować się na konfiguracji RS. W tym momencie SharePoint jest zainstalowany na serwerze SharePoint i skonfigurowany jako **Classic Auth Site** na **porcie 80**. Co więcej, na serwerze RS **właśnie zainstalowałem Reporting Services** i to wszystko.