---
title: Requisitos de nível de confiança
type: docs
weight: 190
url: /pt/net/declaration/
keywords:
- nível de confiança
- Permissão de confiança total
- confiança parcial
- Confiança Média
- segurança de acesso ao código
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Qual nível de confiança de segurança de acesso ao código o Aspose.Slides para .NET necessita: confiança total no .NET Framework e nenhuma configuração de confiança no .NET 6 e posteriores."
---
## **Visão geral**

Níveis de confiança de segurança de acesso ao código (CAS) existem somente no .NET Framework. Este artigo explica o que eles significam para o Aspose.Slides para .NET: a biblioteca requer confiança total no .NET Framework, e no .NET 6 e versões posteriores não há nível de confiança para configurar.

## **.NET Framework**

O Aspose.Slides requer confiança total no .NET Framework. Ele não funciona sob confiança parcial, como em uma aplicação ASP.NET configurada para Medium Trust (`<trust level="Medium" />`): a criação de um objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) falha com uma `SecurityException`.

A Microsoft não trata mais a confiança parcial do ASP.NET como forma de isolar aplicativos uns dos outros, e recomenda executar os aplicativos em pools de aplicativos separados. Veja [ASP.NET Partial Trust does not guarantee application isolation](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 and Later**

A segurança de acesso ao código não está disponível no .NET 6 e versões posteriores, portanto não há nível de confiança a ser concedido. O Aspose.Slides é executado com as permissões da conta que executa seu aplicativo. Para restringir o que um aplicativo pode acessar, a Microsoft recomenda limites do sistema operacional, como contas de usuário, contêineres ou máquinas virtuais. Veja [Code access security (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **Perguntas Frequentes**

**Posso usar o Aspose.Slides com um provedor de hospedagem que executa aplicativos ASP.NET em Medium Trust?**

Não em Medium Trust. No .NET Framework, a aplicação que usa o Aspose.Slides deve ser executada com confiança total.