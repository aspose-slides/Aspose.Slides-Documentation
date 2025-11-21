---
title: 为什么不自动化
type: docs
weight: 40
url: /zh/net/why-not-automation/
keywords:
- 自动化
- Microsoft Office
- 比较
- 安全性
- 稳定性
- 可扩展性
- 功能
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解为何 Office 自动化对服务器和服务存在风险，并看看 Aspose.Slides 如何为 PowerPoint 和 OpenDocument 提供更安全、更快速的演示文稿处理。"
---

## **重要问题**
- 为什么 Aspose 组件比 Microsoft Office Automation 更佳？

我们在 Aspose 经常听到两个问题：

- 您的产品是否需要先安装 Microsoft Office 才能运行？

简短而直接的答案——**否**。 

Aspose 及其组件完全独立，未与 Microsoft Corporation 关联、授权、赞助或以其他方式获得批准。

- 为什么要使用 Aspose 产品而不是 Microsoft Office Automation？

首先，使用 Aspose.Slides 可享受许多[优势](https://docs.aspose.com/slides/net/product-overview/)。 

其次，Microsoft 本身强烈**不建议**在软件解决方案中使用 Office Automation。 

## **概述**
正如前文所述，Aspose 组件是自动化的更佳替代方案，原因有多方面。关键原因包括：

- 安全性
- 稳定性
- 可扩展性/速度
- 价格
- 功能

下面的段落进一步阐述了这些关键原因。 
## **安全性**
以下摘自 Microsoft 文章的原文： 

> "Office 应用程序从未设计用于服务器端使用，因此未考虑分布式组件面临的安全问题。Office 不会验证传入请求，也不能保护您免于意外运行宏，或从服务器端代码启动可能运行宏的其他服务器。不要打开来自匿名 Web 的上传到服务器的文件！根据上次设置的安全设置，服务器可以在 Administrator 或 System 上下文中以完整特权运行宏，从而危及您的网络！此外，Office 使用许多客户端组件（如 Simple MAPI、WinInet、MSDAIPP），这些组件可能缓存客户端身份验证信息以加快处理速度。如果在服务器端自动化 Office，一个实例可能为多个客户端提供服务，并且由于该会话已缓存身份验证信息，可能导致一个客户端使用另一个客户端的缓存凭据，从而通过冒充其他用户获得未授权的访问权限。"

Aspose 产品非常**安全**。Aspose 组件在与所有 ASP.NET 应用程序相同的用户上下文中运行（在 ASPNET 用户下）。因此，Aspose 组件**不会**构成安全风险，也不会消耗关键系统资源。此外，当 Aspose 组件打开文档时，宏不会自动运行。Aspose 组件旨在帮助开发人员创建、操作和保存 Office 文件。 

{{% alert color="primary" %}} 

与 Microsoft Office 套件相关的任何风险均不适用于 Aspose 组件。

{{% /alert %}} 

## **稳定性**
此文本直接摘自前文引用的 Microsoft 文章： 

> "Office 2000、Office XP 和 Office 2003 使用 Microsoft Windows Installer（MSI）技术，使终端用户的安装和自我修复更容易。MSI 引入了“首次使用时安装”的概念，允许在运行时动态安装或配置功能（针对系统，或更常针对特定用户）。在服务器端环境中，这既会降低性能，又会增加出现对话框要求用户批准安装或提供适当安装盘的可能性。尽管此设计旨在提高 Office 作为终端用户产品的弹性，但 Office 对 MSI 功能的实现对服务器端环境来说适得其反。此外，Office 的整体稳定性在服务器端运行时无法得到保证，因为它并未针对这种使用场景进行设计或测试。在网络服务器上将 Office 作为服务组件使用可能会降低该机器的稳定性，进而影响整个网络的稳定性。如果计划在服务器端自动化 Office，请尝试将程序隔离到一台专用计算机上，以免影响关键功能，并在需要时能够重新启动。"

由于 Aspose 组件打包为单个 DLL，用户永远不需要安装额外的部件或组件即可运行。Aspose 组件仅被 .NET 应用程序使用，且组件代码中没有任何需要等待人工响应的部分。 

{{% alert color="primary" %}} 

Aspose 组件经过严格测试，已证实非常稳定。Aspose 组件被[众多公司](http://www.aspose.com/Corporate/Aspose/Customerlist.html)使用，如 **IBM**、**Hilton**、**Reader's Digest**、**Bank of America**以及其他多个行业的领先组织。 

{{% /alert %}} 

## **可扩展性/速度**
以下摘自 Microsoft 文章的原文： 

> "服务器端组件需要高度可重入、多线程 COM 组件，具备最小开销并能为多个客户端提供高吞吐量。Office 应用程序在几乎所有方面都恰恰相反。它们是非可重入、基于 STA 的自动化服务器，旨在为单一客户端提供多样且资源密集的功能。作为服务器端解决方案，它们的可扩展性很差，而且对关键元素（如内存）有固定限制，无法通过配置更改。更重要的是，它们使用全局资源（如内存映射文件、全局加载项或模板以及共享自动化服务器），这会限制并发实例的数量，并在多客户端环境中导致竞争条件。计划同时运行多个 Office 应用实例的开发者需要考虑池化或串行访问 Office 应用，以避免潜在的死锁或数据损坏。" 

Aspose 组件极具可扩展性且速度极快。Office 应用程序并未设计用于同时被数百甚至数千用户使用，而 Aspose 组件正是为此而生。我们的组件是纯 .NET 解决方案。 

{{% alert color="primary" %}} 

Aspose 组件在单台服务器（为单一应用供能）或负载均衡的 Web 形式（为企业级应用供能）上都表现出色，性能完美无瑕。

{{% /alert %}} 

## **价格**
当应用程序使用 Microsoft Office Automation 时，需要为每台运行该应用的机器购买 Microsoft Office。虽然应用程序可能需要创建或操作大量 Office 文件，但此过程并不依赖 Microsoft Office。 

{{% alert color="primary" %}} 

Aspose 提供非常[具成本效益](https://purchase.aspose.com/)且免版税的再分发许可，允许无限用户部署，无需担忧许可证问题。 

{{% /alert %}} 

在创建基于 Web 的应用程序时，需要记住 Microsoft Office Automation 组件既未针对服务器端解决方案定价，也未获得相应授权。因此，使用 Microsoft Office 组件的 Web 应用程序没有合适的许可证方案。而 Aspose 则为基于服务器的应用程序提供了非常[具成本效益](https://purchase.aspose.com/)的解决方案。

## **功能**
Aspose 组件提供管理 Office 文件所需的一切功能，甚至更多。我们基于帮助开发人员以最少的工作量实现最佳结果的理念设计这些组件。 

{{% alert color="primary" %}} 

与 Office Automation 不同，Aspose 组件提供了许多强大且省时的功能。 

{{% /alert %}} 

例如，[Aspose.Cells](https://products.aspose.com/cells/net/) 让开发人员能够直接从 **DataTable** 或 **DataView** 导入数据到 Excel 文件中。[Aspose.Words](https://products.aspose.com/words/net/) 提供类似功能，允许开发人员直接从任何 .NET 数据对象填充 Word（即邮件合并）文档。Aspose 系列中的每个[组件](https://products.aspose.com/total/net/)都有其独特且强大的功能。 

购买 Aspose 组件的最大好处是可以获得我们开发团队的支持。例如，如果您使用 Office Automation 对象并需要某些功能，获得这些功能的可能性极低。然而，Aspose 组件的情况则截然不同。 

{{% alert color="primary" %}} 

我们的开发团队了解，若贵公司需要的功能，也很可能其他公司同样需要。虽然我们无法实现所有请求的功能，但会根据客户反馈尽可能多地添加功能。 

{{% /alert %}} 

我们的团队在提供帮助时始终保持开放和灵活，这也是 Aspose 组件能够发展至今如此强大的原因。 

## **结论**
{{% alert color="primary" %}} 

本文仅覆盖了 Aspose 组件优于 Office Automation 的一些关键点，实际优势远不止这些。我们只列举了部分主要优势。 

此外，所有 Aspose 产品和组件均提供无风险、无义务的[评估版](https://downloads.aspose.com/slides/net)。我们鼓励您利用评估版，了解 Aspose 能为您的应用或业务带来哪些价值。 

{{% /alert %}}