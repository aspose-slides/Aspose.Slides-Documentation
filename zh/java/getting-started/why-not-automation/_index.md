---
title: 为什么不使用自动化
type: docs
weight: 170
url: /zh/java/why-not-automation/
keywords:
- 自动化
- Microsoft Office
- 对比
- 安全
- 稳定性
- 可扩展性
- 功能
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "了解为何 Office 自动化在服务器和服务上风险很大，以及 Aspose.Slides 如何为 PowerPoint 和 OpenDocument 提供更安全、更快速的演示处理。"
---
## **介绍**

Aspose 组件是自动化的更佳替代方案，有多个原因。关键原因包括：

- 安全
- 稳定性
- 可扩展性/速度
- 成本
- 功能

下面对每个关键点进行更详细的说明。

## **重要问题**

我们在 Aspose 经常听到两个问题：

- 您的产品是否需要安装 Microsoft Office 才能运行？

简短而直接的回答是 **NO**。

- 为什么要使用 Aspose 产品而不是 Microsoft Office 自动化？

首先，使用 Aspose.Slides 时您可以获得许多[好处](/slides/zh/java/product-overview/)。

其次，Microsoft 本身强烈**不建议**在软件解决方案中使用 Office 自动化。

## **安全**

下面是来自 Microsoft 文章的直接引用：

*"Office 应用程序从未设计用于服务器端使用，因此没有考虑分布式组件面临的安全问题。Office 不会对传入请求进行身份验证，也无法防止您在服务器端代码中意外运行宏或启动可能运行宏的其他服务器。不要打开来自匿名 Web 上传到服务器的文件！根据上次设置的安全设置，服务器可以在管理员或系统上下文中以完整权限运行宏，从而危及您的网络！此外，Office 使用许多客户端组件（如 Simple MAPI、WinInet、MSDAIPP），这些组件可能会缓存客户端身份验证信息以加快处理速度。如果在服务器端自动化 Office，一个实例可能为多个客户端提供服务，并且由于该会话的身份验证信息已被缓存，可能会出现一个客户端使用另一个客户端的缓存凭据，从而通过冒充其他用户获得未授权的访问权限。*"

Aspose 产品非常安全。Aspose 组件不会对关键系统资源构成潜在风险。此外，当文档由 Aspose 组件打开时，宏不会自动运行。Aspose 组件的构建目标是让开发人员能够创建、操作并保存 Office 文件。与 Microsoft Office 包相关的风险并不固有于 Aspose 组件。

## **稳定性**

下面是来自 Microsoft 文章的直接引用：

*"Office 2000、Office XP 和 Office 2003 使用 Microsoft Windows Installer（MSI）技术，使终端用户的安装和自修复更加简便。MSI 引入了“首次使用时安装”的概念，允许在运行时（针对系统或更常见的针对特定用户）动态安装或配置功能。在服务器端环境中，这既会降低性能，又会增加出现对话框的可能性，提示用户批准安装或提供适当的安装光盘。尽管此设计旨在提升 Office 作为终端用户产品的弹性，但 Office 对 MSI 功能的实现却在服务器端环境中适得其反。此外，由于未针对这种使用方式进行设计或测试，Office 在服务器端运行时的整体稳定性无法得到保证。在网络服务器上将 Office 作为服务组件使用可能会降低该机器的稳定性，进而影响整个网络的稳定性。如果您计划在服务器端自动化 Office，请尝试将该程序隔离到一台专用计算机上，以免影响关键功能，并且该计算机可以根据需要重新启动。*"

Aspose 组件已通过彻底测试，极其稳定。Aspose 组件已被[公司](https://about.aspose.com/customers/)如 **Bank of America** 等广泛使用。

## **可扩展性/速度**

下面是来自 Microsoft 文章的直接引用：

*"服务器端组件需要高度可重入、支持多线程的 COM 组件，具有最小的开销和对多个客户端的高吞吐量。Office 应用程序在几乎所有方面恰恰相反。它们是非可重入的、基于 STA 的自动化服务器，旨在为单个客户端提供多样但资源密集的功能。作为服务器端解决方案，它们的可扩展性有限，并且对重要元素（如内存）有固定限制，无法通过配置更改。更重要的是，它们使用全局资源（例如内存映射文件、全局加载项或模板以及共享的自动化服务器），这可能限制并发运行的实例数量，并在多客户端环境中配置时导致竞争条件。计划同时运行多个 Office 应用实例的开发人员需要考虑 ***Pooling*** 或 ***Serializing Access*** 到 Office 应用，以避免潜在的 ***Deadlocks*** 或 ***Data Corruption***。*"

Aspose 组件高度可扩展且速度极快。Office 应用程序并未为数百甚至数千用户同时使用而设计，而 Aspose 组件正是为此而生。无论是在单一服务器上为单个应用供能，还是在负载均衡的 Web 服务器集群上为企业级应用供能，我们的组件都能无缝运行。

## **价格**

当应用程序使用 Microsoft Office 自动化时，必须为运行该应用的每台机器购买 Microsoft Office 副本。很多情况下，应用程序需要创建或操作 Office 文件，却并不要求用户拥有 Microsoft Office。Aspose 提供非常[成本效益高](https://purchase.aspose.com/)且免版税的再发行许可证，允许无限数量的用户部署，无需担心授权问题。

在创建基于 Web 的应用时，需要了解 Microsoft Office 自动化组件并未为服务器端解决方案定价或授权；因此，没有合适的授权方案来部署使用 Microsoft Office 组件的 Web 应用。Aspose 同样为服务器端应用提供了成本效益高的解决方案。

## **功能**

Aspose 组件提供了管理 Office 文件所需的一切以及更多功能。它们的设计理念是让开发人员用最少的工作实现最大的成果。与 Office 自动化不同，Aspose 组件提供了许多强大且省时的功能。例如，[Aspose.Cells](https://products.aspose.com/cells/java/) 让开发人员能够直接将 **DataTable** 或 **DataView** 导入 Excel 文件。[Aspose.Words](https://products.aspose.com/words/java/) 提供了类似的功能，允许开发人员填充 Word（邮件合并）文档。[每个组件](https://products.aspose.com/total/java/) 在 Aspose 家族中都拥有自己独特且强大的功能。

购买 Aspose 组件（或如 [Aspose.Total](https://products.aspose.com/total/java/) 之类的组件套件）最好的部分是能够获得我们开发团队的支持。我们的开发团队深知，如果贵公司需要的功能很可能其他公司也会需要。虽然并非所有功能请求都能实现，但我们的团队在提供帮助时始终保持开放和灵活的心态。这种思维方式帮助 Aspose 组件变得如此强大。如果您需要的功能是 Office 自动化对象中已有的，那么它们被加入的可能性非常低。

## **结论**
{{% alert color="info" title="注意" %}}

虽然本文已经覆盖了许多 Aspose 组件优于 Office 自动化的关键点，但实际上还有更多。本篇文章仅重点说明了最核心的要点。所有不同的 Aspose 组件均提供免费、无义务的[评估版本](https://releases.aspose.com/slides/zh/java/)。我们鼓励您利用该评估版本，进一步了解 Aspose 能为您的应用实现哪些可能。

{{% /alert %}}