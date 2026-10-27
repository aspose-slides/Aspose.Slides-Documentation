---
title: Interrupt presentation processing
description: Interrupt a long presentation load or export operation.
type: docs
url: /features/cancel-processing/
weight: 290
feature_id: cancel-processing
feature_group: operations
translationKey: slides-feature-cancel-processing
feature_catalogue_version: 2
feature_guides:
- /slides/net/support-for-interruptable-library/
---

## **Overview**

Attach the library's interruption mechanism when opening a presentation, then signal it when your application needs to stop processing. This is useful for cancelled user requests or jobs that should no longer continue. Keep cancellation state alongside the job in your application.

## **FAQ**

**Can I use the output from an interrupted save?**

Discard it. A save can return after interruption with incomplete output, so your application must track cancellation rather than treat a normal return as completion.

## **Guides**

- [Support For Interruptable Library (.NET)](/slides/net/support-for-interruptable-library/)

Related feature: [Track export progress](/slides/features/export-progress/).
