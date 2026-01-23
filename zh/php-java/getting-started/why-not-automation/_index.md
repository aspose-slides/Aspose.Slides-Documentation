---
title: 为什么不使用自动化
type: docs
weight: 50
url: /zh/php-java/why-not-automation/
keywords:
- 自动化
- 微软 Office
- 比较
- 安全性
- 稳定性
- 可伸缩性
- 功能
- PowerPoint
- OpenDocument
- 演示
- PHP
- Aspose.Slides
description: "发现为何在服务器和服务中使用 Office 自动化存在风险，并了解 Aspose.Slides 如何为 PowerPoint 和 OpenDocument 提供更安全、更快速的演示处理。"
---

{{% alert color="primary" %}} 

在 Aspose，这里我们最常听到的两个问题是：

第一个是 **您的产品是否需要安装 Microsoft Office 才能运行？** 

简短直接的答案是 **否**。Aspose 及其组件完全独立，未与 Microsoft Corporation 关联，也未获得其授权、赞助或其他任何形式的认可。

接下来常见的第二个问题是 **为什么要使用 Aspose 产品而不是使用 Microsoft Office 自动化？** 

这个问题没有那么容易回答。我们能给出的最简短答案是原因很多，其中最重要的一点是 **Microsoft 本身强烈建议不要在软件解决方案中使用 Office 自动化** 

{{% /alert %}} 
## **概述**
如上所述，Aspose 组件是自动化的更佳替代方案的原因有多条。关键原因包括：

- 安全性
- 稳定性
- 可伸缩性/速度
- 价格
- 功能

下面对每个关键点进行更详细的阐述。同时请务必访问 **附加信息** 部分，该部分提供独立用户评估的链接。 
## **安全性**
以下摘自 Microsoft 文章的原文：


*"Office 应用程序从未设计用于服务器端使用，因此未考虑分布式组件面临的安全问题。Office 不会对传入请求进行身份验证，也无法防止您在服务器端代码中意外运行宏或启动可能运行宏的其他服务器。不要打开从匿名网站上传到服务器的文件！根据上一次设置的安全设置，服务器可能在管理员或系统上下文中以完整特权运行宏，从而危及您的网络！此外，Office 使用许多客户端组件（如 Simple MAPI、WinInet、MSDAIPP），这些组件会缓存客户端身份验证信息以加快处理速度。如果在服务器端自动化 Office，单个实例可能为多个客户端提供服务，并且由于该会话的身份验证信息已被缓存，导致一个客户端可以使用另一个客户端的缓存凭据，从而通过冒充其他用户获得未授权的访问权限。"*


Aspose 产品非常安全。Aspose 组件不会对关键系统资源构成潜在风险。此外，当文档由 Aspose 组件打开时，宏不会自动运行。Aspose 组件的构建目标是让开发者创建、操控和保存 Office 文件。Microsoft Office 包的风险并非 Aspose 组件所固有。 
## **稳定性**
以下摘自 Microsoft 文章的原文：


*"Office 2000、Office XP 和 Office 2003 使用 Microsoft Windows Installer（MSI）技术，使最终用户的安装和自我修复更容易。MSI 引入了“首次使用时安装”的概念，允许在运行时（针对系统或更常针对特定用户）动态安装或配置功能。在服务器端环境中，这既会降低性能，又会增加出现对话框要求用户批准安装或提供合适安装盘的可能性。虽然该设计旨在提升 Office 作为最终用户产品的弹性，但 Office 对 MSI 功能的实现却在服务器端环境中适得其反。此外，Office 的整体稳定性在服务器端运行时无法保证，因为它并未针对这种使用方式进行设计或测试。将 Office 用作网络服务器上的服务组件可能会降低该机器的稳定性，进而影响整个网络的稳定性。如果计划在服务器端自动化 Office，请尝试将程序隔离到一台不能影响关键功能且可根据需要重启的专用计算机上。"*


Aspose 组件经过严格测试，极其稳定。Aspose 组件已被[公司](https://about.aspose.com/customers)如 **IBM**、**Hilton**、**Reader's Digest**、**Bank of America** 等众多企业使用。 
## **可伸缩性/速度**
以下摘自 Microsoft 文章的原文：


*"服务器端组件需要高度可重入、支持多线程的 COM 组件，具有最小的开销和对多个客户端的高吞吐量。Office 应用程序在几乎所有方面恰恰相反。它们是非可重入的、基于 STA 的自动化服务器，旨在为单个客户端提供多样且资源密集的功能。它们作为服务器端解决方案的可伸缩性很差，且对关键资源（如内存）有固定限制，无法通过配置更改。更重要的是，它们使用全局资源（如内存映射文件、全局加载项或模板以及共享的自动化服务器），这会限制并发运行的实例数量，并在多客户端环境中导致竞争条件。计划同时运行多个 Office 应用程序实例的开发者需要考虑 *池化* 或 *串行化访问* Office 应用程序，以避免潜在的 *死锁* 或 *数据损坏*。"*


Aspose 组件高度可伸缩，速度极快。Office 应用程序并非为数百乃至数千用户同时使用而设计，而 Aspose 组件正是为此而生。我们的组件在单服务器、单应用或负载均衡的 Web 表单中均能无缝运行，支撑企业级应用。 
## **价格**
当应用程序使用 Microsoft Office 自动化时，需要为每台运行该应用的机器购买一份 Microsoft Office。许多情况下，应用程序需要创建或操作 Office 文件，却并不需要用户拥有 Microsoft Office。Aspose 提供非常[性价比高](https://purchase.aspose.com/)且免版税的再分发许可，允许无限用户部署，无需担心授权问题。


在创建基于 Web 的应用时，需要注意 Microsoft Office 自动化组件并未针对服务器端解决方案定价或授权；因此，没有合适的授权方案可以部署使用 Microsoft Office 组件的 Web 应用。Aspose 也为基于服务器的应用提供了极具[性价比高](https://purchase.aspose.com/)的解决方案。 
## **功能**
Aspose 组件提供管理 Office 文件所需的一切功能，甚至更多。它们的设计理念是让开发者以最少的工作量实现最大的成果。与 Office 自动化不同，Aspose 组件提供许多强大且节省时间的功能。例如，[Aspose.Cells](https://products.aspose.com/cells/php-java/) 让开发者能够直接将 **DataTable** 或 **DataView** 导入到 Excel 文件中。[每个组件](https://products.aspose.com/total/php-java/) 都拥有自己独特且强大的功能集。


购买 Aspose 组件（或如[Aspose.Total](https://products.aspose.com/total/php-java/) 之类的组件套件）的最佳收益是可以直接获得我们开发团队的支持。我们的开发团队深知，如果贵公司需要某项功能，其他公司很可能也有相同需求。虽然并非所有功能请求都能实现，但我们的团队在提供帮助时始终保持开放和灵活的心态。这种思维方式帮助 Aspose 组件变得如此强大。如果您仍然需要 Office 自动化对象的额外功能，获得它们被加入的可能性极低。 
## **结论**
{{% alert color="primary" %}} 

虽然本文已覆盖了 Aspose 组件优于 Office 自动化的众多关键点，但实际上远不止这些。本文仅着重介绍最核心的要点。所有不同的 Aspose 组件都提供免费、无义务的[评估版](https://downloads.aspose.com/slides/java)。我们鼓励您利用该评估版，深入了解 Aspose 能为您的应用实现的功能。 

{{% /alert %}}