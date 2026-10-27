---
title: Process separate presentations in parallel
description: Run independent presentation jobs on separate threads.
type: docs
url: /features/parallel-processing/
weight: 1570
feature_id: parallel-processing
feature_group: runtime
translationKey: slides-feature-parallel-processing
feature_catalogue_version: 2
feature_guides:
- /slides/net/multithreading/
---

## **Overview**

Process several presentations in parallel by giving each worker its own presentation instance. Your application controls scheduling, output paths and resource use. This is useful for a server that handles independent documents at the same time.

## **FAQ**

**Can several threads load, save or clone the same presentation instance?**

Do not share a presentation instance for those operations. Apply licensing outside concurrent work as well, since license setup is not thread-safe.

## **Guides**

- [Multithreading in Aspose.Slides for .NET](/slides/net/multithreading/)

Related feature: [Process multiple presentations in a loop](/slides/features/process-multiple-files/).
